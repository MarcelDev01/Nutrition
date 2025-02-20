using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Models;
using Nutrition.Models.DataBase;
using Nutrition.Models.Login;
using Nutrition.Services.Login;
using System.Security.Claims;

namespace Nutrition.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _LoginService;

        public LoginController(ILoginService loginService)
        {
            _LoginService = loginService;  
        }

        #region Views
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IsValidLogin([FromBody] LoginViewModel login)
        {
            if (login == null || string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                return Json(new { success = false, message = "E-mail e senha são obrigatórios" });
            }

            bool isValid = _LoginService.ValidLogin(login.Email, login.Password);

            if (!isValid)
            {
                return Json(new { success = false, message = "Usuário ou senha inválidos" });
            }

            CreateClaimAndCookies(login);

            return Json(new { success = true, message = "Login realizado com sucesso" });
        }
        #endregion

        #region Logout

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            var l_SignOutTask = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            l_SignOutTask.Wait();

            return RedirectToAction("Index", "Login");
        }

        private void CreateClaimAndCookies(LoginViewModel login)
        {
            try
            {
                // Criar Claims (dados do usuário autenticado)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { IsPersistent = true };

                // Criar o Cookie de Autenticação
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties).Wait();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
