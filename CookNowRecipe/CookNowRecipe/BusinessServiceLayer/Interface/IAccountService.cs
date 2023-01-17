using CookNowRecipe.ViewModels;

namespace CookNowRecipe.BusinessServiceLayer.Interface
{
    public interface IAccountService
    {
        List<int> Login(LoginViewModel model);
        bool Register(RegisterViewModel model);
        string FindRole(int RoleId);
    }
}
