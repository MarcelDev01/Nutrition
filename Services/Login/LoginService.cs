using Nutrition.Models.DataBase;
using Nutrition.Models.Helpers;

namespace Nutrition.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<Models.DataBase.User> _Repository;

        public LoginService(IRepository<Models.DataBase.User> p_Repository)
        {
            _Repository = p_Repository;
        }

        public IEnumerable<Models.DataBase.User> GetAllUsers()
        {
            try
            {
                IEnumerable<Models.DataBase.User> l_Users = _Repository.GetAll();

                return l_Users;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidLogin(string p_Email, string p_Password)
        {
            try
            {
                bool l_Return = false;
                Models.DataBase.User l_User = new Models.DataBase.User();

                if (string.IsNullOrEmpty(p_Email) || string.IsNullOrEmpty(p_Password))
                {
                    return false;
                }
                else{

                    if (p_Password == PasswordHelper.HashPassword(p_Password))
                        l_Return = _Repository.GetAll().Any(w => w.Email == p_Email && w.Password == p_Password);

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
