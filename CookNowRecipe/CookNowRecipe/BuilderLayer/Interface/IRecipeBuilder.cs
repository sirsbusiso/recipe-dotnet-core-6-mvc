using CookNowRecipe.ViewModels;
using System.Collections.Generic;

namespace CookNowRecipe.BulderLayer.Interface
{
    public interface IRecipeBuilder
    {
        int AddRecipe(AddRecipeViewModel model, int UserId);
        RecipeDetailsViewModel ViewDatails(ViewDetailsViewModel model);
        ResultViewModel GetAll();
        bool SaveImage(AddFileViewModel model);
    }
}
