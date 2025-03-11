using Nutrition.Models.DataBase;

namespace Nutrition.Services.Consultation
{
    public class ConsultationService : IConsultationService
    {
        private readonly IRepository<Models.DataBase.Consultation> _ConsultationRepository;

        public ConsultationService(IRepository<Models.DataBase.Consultation> ConsultationRepository)
        {
            _ConsultationRepository = ConsultationRepository;
        }
        public IEnumerable<Models.DataBase.Consultation> GetConsultations()
        {
            try
            {
                IEnumerable<Models.DataBase.Consultation> l_Consultations = new List<Models.DataBase.Consultation>();

                l_Consultations = _ConsultationRepository.All().ToList();

                return l_Consultations;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteConsultation(decimal p_ConsultationId)
        {
            try
            {
                bool l_Return = false;

                Models.DataBase.Consultation l_Consultation = new Models.DataBase.Consultation();

                if (p_ConsultationId != 0)
                {
                    l_Consultation = _ConsultationRepository.FirstOrDefault(f => f.ConsultationId == p_ConsultationId);

                    _ConsultationRepository.Delete(l_Consultation.ConsultationId);

                    l_Return = true;
                }

                return l_Return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
