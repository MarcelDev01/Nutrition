using Microsoft.AspNetCore.Mvc;

namespace Nutrition.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Methods
        //[HttpGet]
        //public IActionResult GetUsers()
        //{
        //    var users = _LoginService.GetAllUsers(); // Chama o serviço (interface)
        //    return Json(users); // Retorna os dados como JSON para o Vue.js
        //}
        #endregion
    }
}
