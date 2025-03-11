using Nutrition.Models.DataBase;

namespace Nutrition.Services.Trainning
{
    public class TrainningService : ITrainningService
    {
        private readonly IRepository<Models.DataBase.Trainning> _TrainningRepository;

        public TrainningService(IRepository<Models.DataBase.Trainning> TrainningRepository)
        {
            _TrainningRepository = TrainningRepository;
        }

        public IEnumerable<Models.DataBase.Trainning> GetTrainnings()
        {
            try
            {
                IEnumerable<Models.DataBase.Trainning> l_Trainnings = new List<Models.DataBase.Trainning>();

                l_Trainnings = _TrainningRepository.All().ToList();

                return l_Trainnings;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteTrainning(decimal p_TrainningId)
        {
			try
			{
                bool l_Return = false;

                Models.DataBase.Trainning l_Trainning = new Models.DataBase.Trainning();

                if (p_TrainningId != 0)
                {
                    l_Trainning = _TrainningRepository.FirstOrDefault(f => f.TrainningId == p_TrainningId);

                    _TrainningRepository.Delete(l_Trainning.TrainningId);

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
