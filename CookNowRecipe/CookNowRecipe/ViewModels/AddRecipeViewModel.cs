namespace CookNowRecipe.ViewModels
{
    public class AddRecipeViewModel
    {
        public string RecipeName { get; set; }
        public string? Ingredient { get; set; }
        public string? Instructions { get; set; }
        public IFormFile? File { get; set; }

    }
    public class RecipeDetailsViewModel
    {
        public string Author { get; set; }

        public string RecipeName { get; set; }

        public string? Ingredient { get; set; }

        public string? Instructions { get; set; }

        public string? DateCreated { get; set; }
    }
    public class AllRecipeViewModel
    {
        public int? RecId { get; set; }
        public string? RecipeName { get; set; }
        public string FilePath { get; set; }
    }

    public class AddFileViewModel
    {
        public int? RecId { get; set; }

        public string? FileName { get; set; }

        public string FilePath { get; set; }

        public string? FileType { get; set; }
    }

    public class ResultViewModel
    {
        public IEnumerable<AllRecipeViewModel> AllRecipeViewModel { get; set; }
        public int NumberOfRecords { get; set; }
    }

    public class ViewDetailsViewModel
    {
        public int RecId
        {
            get; set;
        }
    }
}
