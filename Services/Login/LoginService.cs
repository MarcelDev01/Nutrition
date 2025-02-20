using Nutrition.Models.DataBase;
using Nutrition.Models.Helpers;

namespace Nutrition.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<User> _Repository;

        public LoginService(IRepository<User> p_Repository)
        {
            _Repository = p_Repository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                IEnumerable<User> l_Users = _Repository.GetAll();

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
                User l_User = new User();

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
