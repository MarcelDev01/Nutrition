namespace Nutrition.Services.Trainning
{
    public interface ITrainningService
    {
        IEnumerable<Models.DataBase.Trainning> GetTrainnings();
        bool DeleteTrainning(decimal p_TrainningId);
    }
}
