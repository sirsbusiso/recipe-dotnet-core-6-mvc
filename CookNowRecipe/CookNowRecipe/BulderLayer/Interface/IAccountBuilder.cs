using CookNowRecipe.ViewModels;

namespace CookNowRecipe.BulderLayer.Interface
{
    public interface IAccountBuilder
    {
        int Login(LoginViewModel model);
        bool Register(RegisterViewModel model);
    }
}
