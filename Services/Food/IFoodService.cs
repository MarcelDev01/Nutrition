namespace Nutrition.Services.Food
{
    public interface IFoodService
    {
        IEnumerable<Models.DataBase.Food> GetFoods();
        bool DeleteFood(decimal p_FoodId);
    }
}
