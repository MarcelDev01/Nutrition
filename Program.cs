using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Nutrition.Models;
using Nutrition.Models.DataBase;
using Nutrition.Services.Login;
using Nutrition.Services.User;

var builder = WebApplication.CreateBuilder(args);

#region Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
#endregion

#region Services
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion

#region Autentica��o
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true; // Evita acesso ao cookie via JavaScript (protege contra XSS)
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // O cookie s� ser� enviado via HTTPS
    options.Cookie.SameSite = SameSiteMode.Strict; // Evita ataques CSRF
});

builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Login/Index"; // Redireciona para login se n�o autenticado
        options.AccessDeniedPath = "/Login/Index"; // Redireciona para erro de permiss�o
        options.ExpireTimeSpan = TimeSpan.FromDays(1); // Tempo de expira��o do cookie
        options.SlidingExpiration = true; // Renova sess�o caso esteja no final de expira��o
    });

builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});


#endregion

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Habilita a autentica��o
app.UseAuthorization();  // Habilita a autoriza��o

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
