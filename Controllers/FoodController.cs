using Microsoft.AspNetCore.Mvc;
using Nutrition.Models.Filters;
using Nutrition.Models.Saves;
using Nutrition.Services.BodyAssessment;
using Nutrition.Services.Food;

namespace Nutrition.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService _FoodService;

        public FoodController(IFoodService foodService)
        {
            _FoodService = foodService;
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
        [HttpPost]
        public IActionResult GetFoods([FromBody] FilterFoodViewModel p_Data)
        {
            var bodies = _FoodService.GetFoods(p_Data);
            return Json(bodies);
        }

        [HttpGet]
        public IActionResult GetDetailsFood(int p_FoodId)
        {
            var bodies = _FoodService.GetDetailsFood(p_FoodId);
            return Json(bodies);
        }

        [HttpPost]
        public IActionResult SaveFood([FromBody] SaveFoodViewModel p_Data)
        {
            if (p_Data == null)
            {
                return BadRequest("Dados inválidos.");
            }

            _FoodService.SaveFood(p_Data);
            return Ok(p_Data);
        }

        [HttpGet]
        public IActionResult DeleteFood(int p_FoodId)
        {
            try
            {
                if (p_FoodId == 0)
                {
                    return BadRequest("Dados Inválidos.");
                }

                bool isDelete = _FoodService.DeleteFood(p_FoodId);

                if (!isDelete)
                {
                    return Json(new { success = false, message = "Exclusão invalida" });
                }

                return Json(new { success = true, message = "Excluído com sucesso" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
