using CookNowRecipe.BulderLayer.Interface;
using CookNowRecipe.BusinessServiceLayer.Interface;
using CookNowRecipe.ViewModels;

namespace CookNowRecipe.BusinessServiceLayer
{
    public class AccountService: IAccountService
    {
        private readonly IAccountBuilder _accountBuilder;

        public AccountService(IAccountBuilder accountBuilder)
        {
            _accountBuilder = accountBuilder;
        }

        public int Login(LoginViewModel model)
        {
            var res = _accountBuilder.Login(model);
            return res;
        }

        public bool Register(RegisterViewModel model)
        {
            var res = _accountBuilder.Register(model);
            return res;
        }
    }
}
