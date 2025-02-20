using Microsoft.AspNetCore.Mvc;

namespace Nutrition.Controllers
{
    public class FoodController : Controller
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
