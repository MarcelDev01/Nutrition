using Microsoft.AspNetCore.Mvc;
using Nutrition.Models.Filters;
using Nutrition.Models.Saves;
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

        [HttpGet]
        public IActionResult DeleteUser(int p_UserId)
        {
            if (p_UserId == 0)
            {
                return BadRequest("Dados inválidos.");
            }

            bool isDelete = _userService.DeleteUser(p_UserId);

            if (!isDelete)
            {
                return Json(new { success = false, message = "Exclusão invalida" });
            }

            return Json(new { success = true, message = "Excluído com sucesso" });
        }
        #endregion
    }
}
