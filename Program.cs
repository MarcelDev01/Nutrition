using Microsoft.EntityFrameworkCore;
using Nutrition.Models;
using Nutrition.Models.DataBase;
using Nutrition.Services.Login;

var builder = WebApplication.CreateBuilder(args);

#region Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
#endregion

#region Services
builder.Services.AddScoped<ILoginService, LoginService>();
#endregion

#region Autenticação
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true; // Evita acesso ao cookie via JavaScript (protege contra XSS)
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // O cookie só será enviado via HTTPS
    options.Cookie.SameSite = SameSiteMode.Strict; // Evita ataques CSRF
});

builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Login/Index"; // Redireciona para login se não autenticado
        options.AccessDeniedPath = "/Login/Error"; // Redireciona para erro de permissão
        options.ExpireTimeSpan = TimeSpan.FromDays(1); // Tempo de expiração do cookie
        options.SlidingExpiration = true; // Renova sessão caso esteja no final de expiração
    });

#endregion

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
