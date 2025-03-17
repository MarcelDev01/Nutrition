using Nutrition.Models.DataBase;
using Nutrition.Models.Filters;
using Nutrition.Models.Saves;
using System;

namespace Nutrition.Services.BodyAssessment
{
    public class BodyAssessmentService : IBodyAssessmentService
    {
        private readonly IRepository<Models.DataBase.BodyAssessment> _BodyAssessmentRepository;
        private readonly IRepository<Models.DataBase.User> _UserRepository;
        private readonly IRepository<Models.DataBase.Consultation> _ConsultationRepository;

        public BodyAssessmentService(IRepository<Models.DataBase.BodyAssessment> BodyAssessmentRepository, 
                                     IRepository<Models.DataBase.User> UserRepository,
                                     IRepository<Models.DataBase.Consultation> ConsultationRepository)
        {
            _BodyAssessmentRepository = BodyAssessmentRepository;
            _UserRepository = UserRepository;
            _ConsultationRepository = ConsultationRepository;
        }

        public IEnumerable<Models.DataBase.BodyAssessment> GetBodyAssessments(FilterBodyAssessment p_Data)
        {
            try
            {
                List<UserIdAndNameViewModel> l_UsersIdAndName = new List<UserIdAndNameViewModel>();
                List<ConsultationIdAndNames> l_ConsultationsIdAndNames = new List<ConsultationIdAndNames>();
                
                List<int> l_UserIds = new List<int>();
                List<int> l_ConsultationIds = new List<int>();

                IEnumerable<Models.DataBase.BodyAssessment> l_BodyAssessments = new List<Models.DataBase.BodyAssessment>();
                IQueryable<Models.DataBase.BodyAssessment> l_QueryableBodyAssessment = _BodyAssessmentRepository.AllNotList();

                l_UsersIdAndName = _UserRepository.All().Select(s => new UserIdAndNameViewModel 
                { 
                    UserId = s.UserId,
                    UserName = s.Name,
                }).ToList();

                l_ConsultationsIdAndNames = _ConsultationRepository.All().Select(s => new ConsultationIdAndNames
                { 
                    ConsultationId = s.ConsultationId,
                    ConsultationName = s.Name,
                }).ToList();

                #region Filters
                if (!string.IsNullOrEmpty(p_Data.User))
                {
                    l_UserIds = l_UsersIdAndName.Where(w => w.UserName.ToUpper().Contains(p_Data.User.ToUpper())).Select(s => s.UserId).Distinct().ToList();
                    l_QueryableBodyAssessment = l_QueryableBodyAssessment.Where(w => l_UserIds.Contains(w.UserId));
                }

                if (!string.IsNullOrEmpty(p_Data.Consultation))
                {
                    l_ConsultationIds = l_ConsultationsIdAndNames.Where(w => w.ConsultationName.ToUpper().Contains(p_Data.Consultation.ToUpper())).Select(s => s.ConsultationId).Distinct().ToList();
                    l_QueryableBodyAssessment = l_QueryableBodyAssessment.Where(w => l_ConsultationIds.Contains(w.ConsultationId));
                }
                #endregion

                l_BodyAssessments = l_QueryableBodyAssessment.ToList();

                return l_BodyAssessments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Models.DataBase.BodyAssessment GetDetailsBodyAssessments(int p_BodyAssessmentId)
        {
            try
            {
                Models.DataBase.BodyAssessment l_Result = new Models.DataBase.BodyAssessment();

                if(p_BodyAssessmentId != 0)
                {
                    l_Result = _BodyAssessmentRepository.GetById(p_BodyAssessmentId);
                }

                return l_Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveBodyAssessment(SaveBodyAssessmentViewModel p_Data) 
        {
            try
            {
                Models.DataBase.BodyAssessment l_BodyAssessmentInsertOrUpdate = new Models.DataBase.BodyAssessment();

                if(p_Data != null)
                {
                    int l_BodyAssessmentIdMax = 0;

                    l_BodyAssessmentInsertOrUpdate.BodyAssessmentId = p_Data.BodyAssessmentId;
                    l_BodyAssessmentInsertOrUpdate.Imc = p_Data.Imc;
                    l_BodyAssessmentInsertOrUpdate.HeightNew = p_Data.HeightNew;
                    l_BodyAssessmentInsertOrUpdate.WeightNew = p_Data.WeightNew;
                    l_BodyAssessmentInsertOrUpdate.FatPercentage = p_Data.FatPercentage;
                    l_BodyAssessmentInsertOrUpdate.FatWeight = p_Data.FatWeight;
                    l_BodyAssessmentInsertOrUpdate.FatVisceralWeight = p_Data.FatVisceralWeight;
                    l_BodyAssessmentInsertOrUpdate.FatVisceralPercentage = p_Data.FatVisceralPercentage;
                    l_BodyAssessmentInsertOrUpdate.LeanMassWeight = p_Data.LeanMassWeight;
                    l_BodyAssessmentInsertOrUpdate.LeanMassPercentage = p_Data.LeanMassPercentage;
                    l_BodyAssessmentInsertOrUpdate.ArmLeft = p_Data.ArmLeft;
                    l_BodyAssessmentInsertOrUpdate.ArmRight = p_Data.ArmRight;
                    l_BodyAssessmentInsertOrUpdate.ForearmLeft = p_Data.ForearmLeft;
                    l_BodyAssessmentInsertOrUpdate.ForearmRight = p_Data.ForearmRight;
                    l_BodyAssessmentInsertOrUpdate.Chest = p_Data.Chest;
                    l_BodyAssessmentInsertOrUpdate.Shoulder = p_Data.Shoulder;
                    l_BodyAssessmentInsertOrUpdate.ThighLeft = p_Data.ThighLeft;
                    l_BodyAssessmentInsertOrUpdate.ThighRight = p_Data.ThighRight;
                    l_BodyAssessmentInsertOrUpdate.CalfLeft = p_Data.CalfLeft;
                    l_BodyAssessmentInsertOrUpdate.CalfRight = p_Data.CalfRight;
                    l_BodyAssessmentInsertOrUpdate.Abdomen = p_Data.Abdomen;
                    l_BodyAssessmentInsertOrUpdate.Hip = p_Data.Hip;
                    l_BodyAssessmentInsertOrUpdate.Neck = p_Data.Neck;
                    l_BodyAssessmentInsertOrUpdate.Waist = p_Data.Waist;
                    l_BodyAssessmentInsertOrUpdate.UserId = p_Data.UserId;
                    l_BodyAssessmentInsertOrUpdate.ConsultationId = p_Data.ConsultationId;

                    if (p_Data.BodyAssessmentId != 0)
                    {
                        l_BodyAssessmentInsertOrUpdate.BodyAssessmentId = p_Data.BodyAssessmentId;

                        _BodyAssessmentRepository.Update(l_BodyAssessmentInsertOrUpdate);
                    }
                    else
                    {
                        l_BodyAssessmentIdMax = GetNextId();

                        l_BodyAssessmentInsertOrUpdate.BodyAssessmentId = l_BodyAssessmentIdMax;

                        _BodyAssessmentRepository.Add(l_BodyAssessmentInsertOrUpdate);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteBodyAssessment(decimal p_BodyAssessmentId)
        {
            try
            {
                bool l_Return = false;

                Models.DataBase.BodyAssessment l_BodyAssessment = new Models.DataBase.BodyAssessment();

                if (p_BodyAssessmentId != 0)
                {
                    l_BodyAssessment = _BodyAssessmentRepository.FirstOrDefault(f => f.BodyAssessmentId == p_BodyAssessmentId);

                    _BodyAssessmentRepository.Delete(l_BodyAssessment.BodyAssessmentId);

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

                IEnumerable<Models.DataBase.BodyAssessment> l_BodyAssessment = _BodyAssessmentRepository.All();

                l_Result = l_BodyAssessment.Count() > 0 ? l_BodyAssessment.Max(m => m.BodyAssessmentId) + 1 : 1;

                return l_Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
