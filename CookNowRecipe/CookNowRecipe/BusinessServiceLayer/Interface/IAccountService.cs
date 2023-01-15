using CookNowRecipe.ViewModels;

namespace CookNowRecipe.BusinessServiceLayer.Interface
{
    public interface IAccountService
    {
        int Login(LoginViewModel model);
        bool Register(RegisterViewModel model);
    }
}
