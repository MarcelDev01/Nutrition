using Nutrition.Models.Filters;
using Nutrition.Models.Saves;

namespace Nutrition.Services.Consultation
{
    public interface IConsultationService
    {
        IEnumerable<Models.DataBase.Consultation> GetConsultations(FilterConsultationViewModel p_Data);
        Models.DataBase.Consultation GetDetailsConsultation(int p_ConsultationId);
        void SaveConsultation(SaveConsultationViewModel p_Data);
        bool DeleteConsultation(decimal p_ConsultationId);
    }
}
