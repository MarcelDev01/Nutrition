using Nutrition.Models.DataBase;
using Nutrition.Models.Filters;
using Nutrition.Models.Saves;

namespace Nutrition.Services.Food
{
    public class FoodService
    {
        private readonly IRepository<Models.DataBase.Food> _FoodRepository;

        public FoodService(IRepository<Models.DataBase.Food> FoodRepository)
        {
            _FoodRepository = FoodRepository;
        }

        public IEnumerable<Models.DataBase.Food> GetFoods(FilterFoodViewModel p_Filters)
        {
            try
            {
                IEnumerable<Models.DataBase.Food> l_Foods = new List<Models.DataBase.Food>();
                IQueryable<Models.DataBase.Food> l_QueryableFood = _FoodRepository.AllNotList();

                #region Filters

                if (!string.IsNullOrEmpty(p_Filters.Name))
                {
                    l_QueryableFood = l_QueryableFood.Where(w => w.Name.ToUpper().Contains(p_Filters.Name));
                }

                #endregion

                l_Foods = l_QueryableFood.ToList();

                return l_Foods;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Models.DataBase.Food GetDetailsFood(int p_FoodId)
        {
            try
            {
                Models.DataBase.Food l_Result = new Models.DataBase.Food();

                if (p_FoodId != 0)
                {
                    l_Result = _FoodRepository.GetById(p_FoodId);
                }

                return l_Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveFood(SaveFoodViewModel p_Data)
        {
            try
            {
                Models.DataBase.Food l_FoodInsertOrUpdate = new Models.DataBase.Food();

                if (p_Data != null)
                {
                    int l_FoodIdMax = 0;

                    l_FoodInsertOrUpdate.Name = p_Data.Name;

                    if (p_Data.FoodId != 0)
                    {
                        l_FoodInsertOrUpdate.FoodId = p_Data.FoodId;

                        _FoodRepository.Update(l_FoodInsertOrUpdate);
                    }
                    else
                    {
                        l_FoodIdMax = GetNextId();

                        l_FoodInsertOrUpdate.FoodId = p_Data.FoodId;

                        _FoodRepository.Add(l_FoodInsertOrUpdate);
                    }
                }
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

        private int GetNextId()
        {
            try
            {
                int l_Result = 0;

                IEnumerable<Models.DataBase.Food> l_Foods = _FoodRepository.All();

                l_Result = l_Foods.Count() > 0 ? l_Foods.Max(m => m.FoodId) + 1 : 1;

                return l_Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
