using Microsoft.AspNetCore.Mvc;

namespace Nutrition.Controllers
{
    public class BodyAssessmentController : Controller
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
