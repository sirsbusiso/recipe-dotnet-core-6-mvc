using CookNowRecipe.BusinessServiceLayer.Interface;
using CookNowRecipe.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CookNowRecipe.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService acountService)
        {
            _accountService = acountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.ErrorMessage = "";
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var results = _accountService.Login(model);
            if(results != 0)
            {
                var cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(1);
                cookieOptions.Path = "/";
                Response.Cookies.Append("UserId", results.ToString(), cookieOptions);
                return RedirectToAction("Index", "Recipe");
            }
            else
            {
                ViewBag.ErrorMessage = "Incorrect username or password";
                return View();
            }
            
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var results = _accountService.Register(model);
            return RedirectToAction("Login");
        }
    }
}
