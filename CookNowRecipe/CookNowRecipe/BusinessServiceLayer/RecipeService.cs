using CookNowRecipe.BulderLayer.Interface;
using CookNowRecipe.BusinessServiceLayer.Interface;
using CookNowRecipe.ViewModels;

namespace CookNowRecipe.BusinessServiceLayer
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeBuilder _recipeBuilder;

        public RecipeService(IRecipeBuilder recipeBuilder)
        {
            _recipeBuilder = recipeBuilder;
        }
        public int AddRecipe(AddRecipeViewModel model, int UserId)
        {
            var res = _recipeBuilder.AddRecipe(model, UserId);
            return res;
        }

        public ResultViewModel GetAll()
        {
            var res = _recipeBuilder.GetAll();
            return res;
        }

        public bool SaveImage(AddFileViewModel model)
        {
            var res = _recipeBuilder.SaveImage(model);
            return res;
        }

        public RecipeDetailsViewModel ViewDatails(int id)
        {
            var res = _recipeBuilder.ViewDatails(id);
            return res;
        }
    }
}
