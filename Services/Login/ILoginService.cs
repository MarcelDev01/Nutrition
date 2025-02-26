using Nutrition.Models.DataBase;

namespace Nutrition.Services.Login
{
    public interface ILoginService
    {
        bool ValidLogin(string p_Email, string p_Password);
    }
}
