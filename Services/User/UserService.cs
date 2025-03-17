using Nutrition.Models.DataBase;
using Nutrition.Models.Saves;
using Nutrition.Models.Filters;
using Nutrition.Models.Helpers;

namespace Nutrition.Services.User
{
    public class UserService : IUserService
    {
		private readonly IRepository<Models.DataBase.User> _UserRepository;
		private readonly IRepository<Permission> _PermissionRepository;

		public UserService(IRepository<Models.DataBase.User> UserRepository, 
			               IRepository<Permission> PermissionRepository)
        {
            _UserRepository = UserRepository;
            _PermissionRepository = PermissionRepository;
        }

        public IEnumerable<Models.DataBase.User> GetUsers(FilterUserViewModel p_Data)
        {
			try
			{
				IEnumerable<Models.DataBase.User> l_Users = new List<Models.DataBase.User>();
                IQueryable<Models.DataBase.User> l_QueryableUser = _UserRepository.AllNotList();

                #region Filters
                if (!string.IsNullOrEmpty(p_Data.Name))
				{
                    l_QueryableUser = l_QueryableUser.Where(w => w.Name.ToUpper().Contains(p_Data.Name.ToUpper()));

                }

				if (!string.IsNullOrEmpty(p_Data.Email))
				{
                    l_QueryableUser = l_QueryableUser.Where(w => w.Email.ToUpper().Contains(p_Data.Email.ToUpper()));
                }
                #endregion

                l_Users = l_QueryableUser.ToList();

                return l_Users;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

        public IEnumerable<Permission> GetPermissions()
        {
            try
            {
				IEnumerable<Permission> l_Permissions = [];

                l_Permissions = _PermissionRepository.All();

                return l_Permissions;
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
					l_User = _UserRepository.GetById(p_UserId);
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
					l_UserInsertOrUpdate.FlgActive = p_Data.FlgActive ? "S" : "N";

					l_UserInsertOrUpdate.Password = PasswordHelper.HashPassword(p_Data.Password);

					if (p_Data.UserId != 0)
					{
						l_UserInsertOrUpdate.UserId = p_Data.UserId;

                        _UserRepository.Update(l_UserInsertOrUpdate);
					}
					else
					{
                        l_UserIdMax = GetNextId();

						l_UserInsertOrUpdate.UserId = l_UserIdMax;

                        _UserRepository.Add(l_UserInsertOrUpdate);
					}
				}
			}
			catch (Exception ex)
			{
                throw ex;
			}
		}

		public bool DeleteUser(int p_UserId) 
		{
			try
			{
				bool l_Result = false;
                Models.DataBase.User l_UserDelete = new Models.DataBase.User();

				if (p_UserId != 0)
				{
					l_UserDelete = _UserRepository.FirstOrDefault(f => f.UserId == p_UserId);

					_UserRepository.Delete(l_UserDelete.UserId);

					l_Result = true;
                }

				return l_Result;
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

                IEnumerable<Models.DataBase.User> l_Users = _UserRepository.All();

                l_Result = l_Users.Count() > 0 ? l_Users.Max(m => m.UserId) + 1 : 1;

				return l_Result;
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
    }
}
