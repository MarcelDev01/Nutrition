using Nutrition.Models.DataBase;

namespace Nutrition.Services.Login
{
    public interface ILoginService
    {
        IEnumerable<User> GetAllUsers();
        bool ValidLogin(string p_Email, string p_Password);
    }
}
