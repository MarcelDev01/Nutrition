namespace Nutrition.Services.Consultation
{
    public interface IConsultationService
    {
        IEnumerable<Models.DataBase.Consultation> GetConsultations();
        bool DeleteConsultation(decimal p_ConsultationId);
    }
}
