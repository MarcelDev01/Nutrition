using Nutrition.Models.DataBase;
using Nutrition.Models.Filters;
using Nutrition.Models.Saves;

namespace Nutrition.Services.Trainning
{
    public class TrainningService : ITrainningService
    {
        private readonly IRepository<Models.DataBase.Trainning> _TrainningRepository;

        public TrainningService(IRepository<Models.DataBase.Trainning> TrainningRepository)
        {
            _TrainningRepository = TrainningRepository;
        }

        public IEnumerable<Models.DataBase.Trainning> GetTrainnings(FilterTrainningViewModel p_Data)
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

        public Models.DataBase.Trainning GetDetailsTrainning(int p_TrainningId)
        {
            try
            {
                Models.DataBase.Trainning l_Result = new Models.DataBase.Trainning();

                if(p_TrainningId != 0)
                {
                    l_Result = _TrainningRepository.GetById(p_TrainningId);
                }

                return l_Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveTrainning(SaveTrainningViewModel p_Data)
        {
            try
            {
                Models.DataBase.Trainning l_TrainningInsertOrUpdate = new Models.DataBase.Trainning();

                if (p_Data != null)
                {
                    int l_TrainningIdMax = 0;

                    l_TrainningInsertOrUpdate.Name = p_Data.Name;
                    l_TrainningInsertOrUpdate.Observation = p_Data.Observation;
                    l_TrainningInsertOrUpdate.CategoryTrainningId = p_Data.CategoryTrainningId;
                    l_TrainningInsertOrUpdate.UserId = p_Data.UserId;
                    l_TrainningInsertOrUpdate.Reps = p_Data.Reps;
                    l_TrainningInsertOrUpdate.Series = p_Data.Series;

                    if (p_Data.TrainningId != 0)
                    {
                        l_TrainningInsertOrUpdate.TrainningId = p_Data.TrainningId;

                        _TrainningRepository.Update(l_TrainningInsertOrUpdate);
                    }
                    else
                    {
                        l_TrainningIdMax = GetNextId();

                        l_TrainningInsertOrUpdate.TrainningId = l_TrainningIdMax;

                        _TrainningRepository.Add(l_TrainningInsertOrUpdate);
                    }
                }

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

        private int GetNextId()
        {
            try
            {
                int l_Result = 0;

                IEnumerable<Models.DataBase.Trainning> l_Trainnings = _TrainningRepository.All();

                l_Result = l_Trainnings.Count() > 0 ? l_Trainnings.Max(m => m.UserId) + 1 : 1;

                return l_Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
