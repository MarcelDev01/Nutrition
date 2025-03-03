using Microsoft.AspNetCore.Mvc;
using Nutrition.Models.User;
using Nutrition.Services.User;

namespace Nutrition.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService; 

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region Views
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        #endregion

        #region Methods
        [HttpPost]
        public IActionResult GetUsers([FromBody] FilterUserViewModel p_Data)
        {
            var users = _userService.GetUsers(p_Data); // Chama o serviço (interface)
            return Json(users); // Retorna os dados como JSON para o Vue.js
        }

        [HttpGet]
        public IActionResult GetPermissions()
        {
            var users = _userService.GetPermissions();
            return Json(users);
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
            return Ok(p_Data);
        }
        #endregion
    }
}
