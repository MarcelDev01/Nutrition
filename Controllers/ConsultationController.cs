using Microsoft.AspNetCore.Mvc;
using Nutrition.Models.Filters;
using Nutrition.Models.Saves;
using Nutrition.Services.Consultation;

namespace Nutrition.Controllers
{
    public class ConsultationController : Controller
    {
        private readonly IConsultationService _ConsultationService;

        public ConsultationController(IConsultationService consultationService)
        {
            _ConsultationService = consultationService;
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
        public IActionResult GetConsultations([FromBody] FilterConsultationViewModel p_Data)
        {
            var bodies = _ConsultationService.GetConsultations(p_Data);
            return Json(bodies);
        }

        [HttpGet]
        public IActionResult GetDetailsConsultation(int p_ConsultationId)
        {
            var bodies = _ConsultationService.GetDetailsConsultation(p_ConsultationId);
            return Json(bodies);
        }

        [HttpPost]
        public IActionResult SaveConsultation([FromBody] SaveConsultationViewModel p_Data)
        {
            if (p_Data == null)
            {
                return BadRequest("Dados inválidos.");
            }

            _ConsultationService.SaveConsultation(p_Data);
            return Ok(p_Data);
        }

        [HttpGet]
        public IActionResult DeleteConsultation(int p_ConsultationId)
        {
            try
            {
                if (p_ConsultationId == 0)
                {
                    return BadRequest("Dados Inválidos.");
                }

                bool isDelete = _ConsultationService.DeleteConsultation(p_ConsultationId);

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
