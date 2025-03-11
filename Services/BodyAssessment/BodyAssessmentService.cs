using Nutrition.Models.DataBase;

namespace Nutrition.Services.BodyAssessment
{
    public class BodyAssessmentService : IBodyAssessmentService
    {
        private readonly IRepository<Models.DataBase.BodyAssessment> _BodyAssessmentRepository;

        public BodyAssessmentService(IRepository<Models.DataBase.BodyAssessment> BodyAssessmentRepository)
        {
            _BodyAssessmentRepository = BodyAssessmentRepository;
        }

        public IEnumerable<Models.DataBase.BodyAssessment> GetBodyAssessments()
        {
            try
            {
                IEnumerable<Models.DataBase.BodyAssessment> l_BodyAssessments = new List<Models.DataBase.BodyAssessment>();

                l_BodyAssessments = _BodyAssessmentRepository.All().ToList();

                return l_BodyAssessments;
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
    }
}
