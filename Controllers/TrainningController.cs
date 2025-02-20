using Microsoft.AspNetCore.Mvc;

namespace Nutrition.Controllers
{
    public class TrainningController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
