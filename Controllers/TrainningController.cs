using Microsoft.AspNetCore.Mvc;
using Nutrition.Models.Filters;
using Nutrition.Models.Saves;
using Nutrition.Services.Trainning;

namespace Nutrition.Controllers
{
    public class TrainningController : Controller
    {
        private readonly ITrainningService _TrainningService;

        public TrainningController(ITrainningService trainningService)
        {
            _TrainningService = trainningService;
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
        public IActionResult GetTrainnings([FromBody] FilterTrainningViewModel p_Data)
        {
            var trainnings = _TrainningService.GetTrainnings(p_Data); // Chama o serviço (interface)
            return Json(trainnings); // Retorna os dados como JSON para o Vue.js
        }

        [HttpGet]
        public IActionResult GetDetailsTrainning(int p_TrainningId)
        {
            var trainnings = _TrainningService.GetDetailsTrainning(p_TrainningId); // Chama o serviço (interface)
            return Json(trainnings); // Retorna os dados como JSON para o Vue.js
        }

        [HttpPost]
        public IActionResult SaveTrainning([FromBody] SaveUserViewModel p_Data)
        {
            if (p_Data == null)
            {
                return BadRequest("Dados inválidos.");
            }

            _TrainningService.SaveTrainning(p_Data);
            return Ok(p_Data);
        }

        [HttpGet]
        public IActionResult DeleteTrainning(int p_TrainningId)
        {
            if (p_TrainningId == 0)
            {
                return BadRequest("Dados inválidos.");
            }

            bool isDelete = _TrainningService.DeleteTrainning(p_TrainningId);

            if (!isDelete)
            {
                return Json(new { success = false, message = "Exclusão invalida" });
            }

            return Json(new { success = true, message = "Excluído com sucesso" });
        }
        #endregion
    }
}
