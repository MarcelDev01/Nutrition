using Microsoft.AspNetCore.Mvc;
using Nutrition.Models.Filters;
using Nutrition.Models.Saves;
using Nutrition.Services.BodyAssessment;

namespace Nutrition.Controllers
{
    public class BodyAssessmentController : Controller
    {
        private readonly IBodyAssessmentService _bodyAssessmentService;

        public BodyAssessmentController(IBodyAssessmentService bodyAssessmentService)
        {
            _bodyAssessmentService = bodyAssessmentService;
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
        public IActionResult GetBodyAssessment([FromBody] FilterBodyAssessment p_Data)
        {
            var bodies = _bodyAssessmentService.GetBodyAssessments(p_Data);
            return Json(bodies);
        }

        [HttpGet]
        public IActionResult GetDetailsBodyAssessments(int p_BodyAssessmentId)
        {
            var bodies = _bodyAssessmentService.GetDetailsBodyAssessments(p_BodyAssessmentId);
            return Json(bodies);
        }

        [HttpPost]
        public IActionResult SaveBodyAssessment([FromBody] SaveBodyAssessmentViewModel p_Data)
        {
            if (p_Data == null)
            {
                return BadRequest("Dados inválidos.");
            }

            _bodyAssessmentService.SaveBodyAssessment(p_Data);
            return Ok(p_Data);
        }

        [HttpGet]
        public IActionResult DeleteBodyAssessment(int p_BodyAssessmentId)
        {
            try
            {
                if(p_BodyAssessmentId == 0)
                {
                    return BadRequest("Dados Inválidos.");
                }

                bool isDelete = _bodyAssessmentService.DeleteBodyAssessment(p_BodyAssessmentId);

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
