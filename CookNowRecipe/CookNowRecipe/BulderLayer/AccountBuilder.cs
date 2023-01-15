using CookNowRecipe.BulderLayer.Interface;
using CookNowRecipe.Models;
using CookNowRecipe.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace CookNowRecipe.BulderLayer
{
    public class AccountBuilder: IAccountBuilder
    {
        private readonly RecipeDbContext _context;

        public AccountBuilder(RecipeDbContext context)
        {
            _context = context;
        }

        public int Login(LoginViewModel model)
        {
           
                var exist = _context.TbUsers.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
                if (exist == null)
                {
                    return 0;
                }
                else
                {
                    return exist.UserId;
                }
            
        }

        public bool Register(RegisterViewModel model)
        {
            
                var user = new TbUser()
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password,
                    RoleId = 1

                };
                _context.TbUsers.Add(user);
                _context.SaveChanges();
                return true;
            
        }
    }
}
