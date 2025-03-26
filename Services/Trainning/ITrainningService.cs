using Nutrition.Models.Filters;
using Nutrition.Models.Saves;

namespace Nutrition.Services.Trainning
{
    public interface ITrainningService
    {
        IEnumerable<Models.DataBase.Trainning> GetTrainnings(FilterTrainningViewModel p_Data);
        Models.DataBase.Trainning GetDetailsTrainning(int p_TrainningId);
        void SaveTrainning(SaveTrainningViewModel p_Data);
        bool DeleteTrainning(decimal p_TrainningId);
    }
}
