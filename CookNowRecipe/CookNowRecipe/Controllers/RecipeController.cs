using CookNowRecipe.BusinessServiceLayer.Interface;
using CookNowRecipe.ViewModels;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CookNowRecipe.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RecipeController(IRecipeService recipeService, IWebHostEnvironment webHostEnvironment)
        {
            _recipeService = recipeService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int Num)
        {
            var results = _recipeService.GetAll();
            if (results.NumberOfRecords != 0)
            {
                ViewBag.NoRecords = "";
                ViewBag.Details = "";

                ViewBag.Results = results.AllRecipeViewModel;
                ViewBag.NumberOfRecords = results.NumberOfRecords;
                return View();
            }
            else
            {
                ViewBag.NoRecords = "No Records Found";
                ViewBag.Details = "";

                ViewBag.Results = results;

                return View();
            }

        }

        [HttpPost]
        public IActionResult Create(AddRecipeViewModel model)
        {
            var userId = Request.Cookies["UserId"];
            var results = _recipeService.AddRecipe(model, Convert.ToInt16(userId));
            if (results != 0)
            {
                var createFilePath = CreateFilePath(model.File, results);
                var saveFile = _recipeService.SaveImage(createFilePath);

            }
            return RedirectToAction("Index");
        }
        public AddFileViewModel CreateFilePath(IFormFile file, int RecId)
        {
            try
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    string folder = "Images";
                    var fileContent = reader.ReadToEnd();
                    var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                    var fileName = parsedContentDisposition.FileName;

                    folder += Guid.NewGuid().ToString() + "_" + file.FileName;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                    var fileModel = new AddFileViewModel()
                    {
                        RecId = RecId,
                        FileName = fileName,
                        FilePath = "/" + folder,
                        FileType = ""
                    };
                    return fileModel;
                }
            }
            catch
            {
                return new AddFileViewModel();
            }
        }

        [HttpPost]
        public IActionResult Details(ViewDetailsViewModel model)
        {
            var results = _recipeService.ViewDatails(model);
            if(results != null)
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                string[] ingredients = results.Ingredient.Split(delimiterChars);
                ViewBag.Ingredients = ingredients;
            }
            ViewBag.Details = results;
            return View();

        }
    }

}
