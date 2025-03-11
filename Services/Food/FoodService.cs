using Nutrition.Models.DataBase;

namespace Nutrition.Services.Food
{
    public class FoodService
    {
        private readonly IRepository<Models.DataBase.Food> _FoodRepository;

        public FoodService(IRepository<Models.DataBase.Food> FoodRepository)
        {
            _FoodRepository = FoodRepository;
        }
        public IEnumerable<Models.DataBase.Food> GetFoods()
        {
            try
            {
                IEnumerable<Models.DataBase.Food> l_Foods = new List<Models.DataBase.Food>();

                l_Foods = _FoodRepository.All().ToList();

                return l_Foods;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteFood(decimal p_FoodId)
        {
            try
            {
                bool l_Return = false;

                Models.DataBase.Food l_Food= new Models.DataBase.Food();

                if (p_FoodId != 0)
                {
                    l_Food = _FoodRepository.FirstOrDefault(f => f.FoodId == p_FoodId);

                    _FoodRepository.Delete(l_Food.FoodId);

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
