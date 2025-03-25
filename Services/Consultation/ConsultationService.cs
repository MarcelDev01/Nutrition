using Nutrition.Models.DataBase;
using Nutrition.Models.Filters;
using Nutrition.Models.Saves;
using System;

namespace Nutrition.Services.Consultation
{
    public class ConsultationService : IConsultationService
    {
        private readonly IRepository<Models.DataBase.Consultation> _ConsultationRepository;

        public ConsultationService(IRepository<Models.DataBase.Consultation> ConsultationRepository)
        {
            _ConsultationRepository = ConsultationRepository;
        }

        public IEnumerable<Models.DataBase.Consultation> GetConsultations(FilterConsultationViewModel p_Data)
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

        public Models.DataBase.Consultation GetDetailsConsultation(int p_ConsultationId)
        {
            try
            {
                Models.DataBase.Consultation l_Result = new Models.DataBase.Consultation();

                if (p_ConsultationId != 0)
                {
                    l_Result = _ConsultationRepository.GetById(p_ConsultationId);
                }

                return l_Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveConsultation(SaveConsultationViewModel p_Data)
        {
            try
            {
                int l_ConsultationIdMax = 0;
                Models.DataBase.Consultation l_ConsutlationInsertOrUpdate = new Models.DataBase.Consultation();

                if(p_Data != null)
                {

                    DateTime l_DateConvert = new DateTime();

                    if (!string.IsNullOrEmpty(p_Data.Date))
                    {
                        l_DateConvert = Convert.ToDateTime(p_Data.Date);
                    }

                    l_ConsutlationInsertOrUpdate.ConsultationId = p_Data.ConsultationId;
                    l_ConsutlationInsertOrUpdate.Name = p_Data.Name;
                    l_ConsutlationInsertOrUpdate.Date = l_DateConvert;
                    l_ConsutlationInsertOrUpdate.UserId = p_Data.UserId;

                    if (p_Data.ConsultationId != 0)
                    {
                        l_ConsutlationInsertOrUpdate.ConsultationId = p_Data.ConsultationId;

                        _ConsultationRepository.Update(l_ConsutlationInsertOrUpdate);
                    }
                    else
                    {
                        l_ConsultationIdMax = GetNextId();

                        l_ConsutlationInsertOrUpdate.ConsultationId = l_ConsultationIdMax;

                        _ConsultationRepository.Add(l_ConsutlationInsertOrUpdate);
                    }
                }

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

        private int GetNextId()
        {
            try
            {
                int l_Result = 0;

                IEnumerable<Models.DataBase.Consultation> l_Consultations = _ConsultationRepository.All();

                l_Result = l_Consultations.Count() > 0 ? l_Consultations.Max(m => m.ConsultationId) + 1 : 1;

                return l_Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
 