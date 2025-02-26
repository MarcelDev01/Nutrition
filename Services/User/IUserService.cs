using Nutrition.Models.DataBase;
using Nutrition.Models.User;

namespace Nutrition.Services.User
{
    public interface IUserService
    {
        IEnumerable<Models.DataBase.User> GetUsers();
        Models.DataBase.User GetDetailsUser(int p_UserId);
        void SaveUser(SaveUserViewModel p_Data);
    }
}
