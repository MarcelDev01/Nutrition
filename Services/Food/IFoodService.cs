using Nutrition.Models.Filters;
using Nutrition.Models.Saves;

namespace Nutrition.Services.Food
{
    public interface IFoodService
    {
        IEnumerable<Models.DataBase.Food> GetFoods(FilterFoodViewModel p_Filters);
        Models.DataBase.Food GetDetailsFood(int p_FoodId);
        void SaveFood(SaveFoodViewModel p_Data);
        bool DeleteFood(decimal p_FoodId);
    }
}
