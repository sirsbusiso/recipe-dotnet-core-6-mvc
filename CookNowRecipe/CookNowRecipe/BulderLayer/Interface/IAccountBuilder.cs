using CookNowRecipe.ViewModels;

namespace CookNowRecipe.BulderLayer.Interface
{
    public interface IAccountBuilder
    {
        List<int> Login(LoginViewModel model);
        bool Register(RegisterViewModel model);
        string FindRole(int RoleId);
    }
}
