namespace Nutrition.Services.BodyAssessment
{
    public interface IBodyAssessmentService
    {
        IEnumerable<Models.DataBase.BodyAssessment> GetBodyAssessments();
        bool DeleteBodyAssessment(decimal p_BodyAssessmentId);
    }
}
