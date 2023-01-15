using CookNowRecipe.BulderLayer.Interface;
using CookNowRecipe.Models;
using CookNowRecipe.ViewModels;
using System.Web;

namespace CookNowRecipe.BulderLayer
{
    public class RecipeBuilder : IRecipeBuilder
    {

        private readonly RecipeDbContext _context;
        private readonly IConfiguration _config;

        public RecipeBuilder(RecipeDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public int AddRecipe(AddRecipeViewModel model, int UserId)
        {
            var encodeHtml = HttpUtility.HtmlEncode(model.Instructions);

            var recipe = new TbRecipe()
            {
                UserId = UserId,
                Ingredient = model.Ingredient,
                Instructions = encodeHtml,
                RecipeName = model.RecipeName,
                DateCreated = DateTime.Now
            };
            _context.Add(recipe);
            _context.SaveChanges();
            return recipe.RecId;

        }
        public ResultViewModel GetAll()
        {
            int numberOfCards = Convert.ToInt16(_config.GetSection("appConfigSettings").GetSection("numberOfCards").Value);

            var allRecipes = new List<AllRecipeViewModel>();

            var res = _context.TbRecipes.ToList();
            var numberOfRecords = res.Count();
            if (res.Count != 0)
            {
                foreach (var r in res)
                {
                    var recipe = new AllRecipeViewModel()
                    {
                        RecId = r.RecId,
                        FilePath = GetFilePath(r.RecId),
                        RecipeName = r.RecipeName
                    };
                    allRecipes.Add(recipe);

                }
            }
            var results = new ResultViewModel()
            {
                AllRecipeViewModel = allRecipes.Take(numberOfCards),
                NumberOfRecords = numberOfRecords
            };
            return results;

        }

        public string GetFilePath(int RecId)
        {

            var filePath = _context.TbRecipeImages.FirstOrDefault(r => r.RecId == RecId);
            if (filePath == null)
            {
                return "";
            }
            else
            {
                return filePath.FilePath;
            }

        }
        public bool SaveImage(AddFileViewModel model)
        {

            var fileImage = new TbRecipeImage()
            {
                RecId = model.RecId,
                FileName = model.FileName,
                FilePath = model.FilePath,
                FileType = model.FileType
            };
            _context.Add(fileImage);
            _context.SaveChanges();
            return true;

        }

        public RecipeDetailsViewModel ViewDatails(int id)
        {

            var res = _context.TbRecipes.FirstOrDefault(r => r.RecId == id);
            if (res == null)
            {
                var recipe = new RecipeDetailsViewModel()
                {
                    RecipeName = res.RecipeName,
                    Author = res.User.FirstName + " " + res.User.LastName,
                    DateCreated = res.DateCreated,
                    Ingredient = res.Ingredient,
                    Instructions = HttpUtility.HtmlDecode(res.Instructions)
                };

                return recipe;
            }
            else
            {
                return new RecipeDetailsViewModel();
            }

        }
    }
}
