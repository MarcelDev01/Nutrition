using Nutrition.Models.Saves;
using Nutrition.Models.Filters;

namespace Nutrition.Services.BodyAssessment
{
    public interface IBodyAssessmentService
    {
        IEnumerable<Models.DataBase.BodyAssessment> GetBodyAssessments(FilterBodyAssessment p_Data);
        Models.DataBase.BodyAssessment GetDetailsBodyAssessments(int p_BodyAssessmentId);
        void SaveBodyAssessment(SaveBodyAssessmentViewModel p_Data);
        bool DeleteBodyAssessment(decimal p_BodyAssessmentId);
    }
}
