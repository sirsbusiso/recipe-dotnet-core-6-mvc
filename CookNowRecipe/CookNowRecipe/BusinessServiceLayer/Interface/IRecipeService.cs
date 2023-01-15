using CookNowRecipe.ViewModels;

namespace CookNowRecipe.BusinessServiceLayer.Interface
{
    public interface IRecipeService
    {
        int AddRecipe(AddRecipeViewModel model, int UserId);
        RecipeDetailsViewModel ViewDatails(int id);
        ResultViewModel GetAll();
        bool SaveImage(AddFileViewModel model); 
    }
}
