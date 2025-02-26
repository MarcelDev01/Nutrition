using Nutrition.Models.DataBase;
using Nutrition.Models.User;

namespace Nutrition.Services.User
{
    public class UserService : IUserService
    {
		private readonly IRepository<Models.DataBase.User> _repository;

		public UserService(IRepository<Models.DataBase.User> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Models.DataBase.User> GetUsers()
        {
			try
			{
				IEnumerable<Models.DataBase.User> l_Users = [];

				l_Users = _repository.GetAll();

                return l_Users;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

		public Models.DataBase.User GetDetailsUser(int p_UserId)
		{
			try
			{
				Models.DataBase.User l_User = new Models.DataBase.User();

				if(p_UserId != 0)
				{
					l_User = _repository.GetById(p_UserId);
				}

				return l_User;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public void SaveUser(SaveUserViewModel p_Data) 
		{
			try
			{
				Models.DataBase.User l_UserInsertOrUpdate = new Models.DataBase.User();

				if (p_Data != null)
				{
					DateTime l_DateConvert = new DateTime();
					DateOnly l_DateOnly = new DateOnly();
					int l_UserIdMax = 0;

					if (!string.IsNullOrEmpty(p_Data.Birthday))
					{
						l_DateConvert = Convert.ToDateTime(p_Data.Birthday);
						l_DateOnly = new DateOnly(l_DateConvert.Year, l_DateConvert.Month, l_DateConvert.Day);
					}

					l_UserInsertOrUpdate.Name = p_Data.Name;
					l_UserInsertOrUpdate.PermissionId = p_Data.Permission;
					l_UserInsertOrUpdate.Age = p_Data.Age;
					l_UserInsertOrUpdate.Birthday = l_DateOnly;
					l_UserInsertOrUpdate.Height = p_Data.Height;
					l_UserInsertOrUpdate.Weight = p_Data.Weight;
					l_UserInsertOrUpdate.Email = p_Data.Email;
					l_UserInsertOrUpdate.Login = p_Data.Login;
					l_UserInsertOrUpdate.Password = p_Data.Password;
					l_UserInsertOrUpdate.FlgActive = p_Data.FlgActive ? "S" : "N";

					if (p_Data.UserId != 0)
					{
                        _repository.Update(l_UserInsertOrUpdate);
					}
					else
                    {
                        l_UserIdMax = _repository.GetAll().Max(x => x.UserId) + 1;

                        l_UserInsertOrUpdate.UserId = l_UserIdMax;

                        _repository.Add(l_UserInsertOrUpdate);
					}
				}
			}
			catch (Exception ex)
			{
                throw ex;
			}
		}
    }
}
