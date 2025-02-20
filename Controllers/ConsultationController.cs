using Microsoft.AspNetCore.Mvc;

namespace Nutrition.Controllers
{
    public class ConsultationController : Controller
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
