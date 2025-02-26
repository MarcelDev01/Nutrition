using Microsoft.AspNetCore.Mvc;
using Nutrition.Models.Login;
using Nutrition.Models.User;
using Nutrition.Services.User;
using System.Xml.Linq;

namespace Nutrition.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService; 

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        #region Methods
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers(); // Chama o serviço (interface)
            return Json(users); // Retorna os dados como JSON para o Vue.js
        }

        [HttpGet]
        public IActionResult GetDetailsUser(int p_UserId)
        {
            var users = _userService.GetDetailsUser(p_UserId); // Chama o serviço (interface)
            return Json(users); // Retorna os dados como JSON para o Vue.js
        }

        [HttpPost]
        public IActionResult SaveUser([FromBody] SaveUserViewModel p_Data)
        {
            if (p_Data == null)
            {
                return BadRequest("Dados inválidos.");
            }

            _userService.SaveUser(p_Data);
            return Ok(p_Data); // Retorna os dados salvos para o Vue.js
        }
        #endregion
    }
}
