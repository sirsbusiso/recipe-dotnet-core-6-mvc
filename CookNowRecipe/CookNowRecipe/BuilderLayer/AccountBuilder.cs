using CookNowRecipe.BulderLayer.Interface;
using CookNowRecipe.Models;
using CookNowRecipe.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace CookNowRecipe.BulderLayer
{
    public class AccountBuilder : IAccountBuilder
    {
        private readonly RecipeDbContext _context;

        public AccountBuilder(RecipeDbContext context)
        {
            _context = context;
        }

        public string FindRole(int RoleId)
        {
            var exist = _context.TbRoles.FirstOrDefault(x => x.RoleId == RoleId);
            if (exist == null)
            {
                return "";
            }
            else
            {
                return exist.RoleName;
            }
        }

        public List<int> Login(LoginViewModel model)
        {
            List<int> Ids = new List<int>();
            var exist = _context.TbUsers.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
            if (exist == null)
            {
                return Ids;
            }
            else
            {
                Ids.Add((int)exist.RoleId);
                Ids.Add(exist.UserId);

                return Ids;
            }

        }


        public bool Register(RegisterViewModel model)
        {
            var userNameExist = _context.TbUsers.FirstOrDefault(x => x.UserName == model.UserName);
            if (userNameExist == null)
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
            else
            {
                return false;
            }


        }
    }
}
