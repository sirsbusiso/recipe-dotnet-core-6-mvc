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
            ViewBag.RoleName = "";
            var results = _accountService.Login(model);
            if(results.Count() != 0)
            {
                var cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(1);
                cookieOptions.Path = "/";
                Response.Cookies.Append("UserId", results[1].ToString(), cookieOptions);
                var RoleName = _accountService.FindRole(results[0]);
                Response.Cookies.Append("RoleName",RoleName, cookieOptions);


                return RedirectToAction("Index", "Recipe");
            }
            else
            {
                ViewBag.RoleName = "";
                ViewBag.ErrorMessage = "Incorrect username or password";
                return View();
            }
            
        }

        //public IActionResult TestJson()
        //{
        //    var data = "This is a test nothing much";
        //    ViewBag.Response = data;

        //    return Json(true, new System.Text.Json.JsonSerializerOptions());
        //}

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var results = _accountService.Register(model);
            if (results)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.ErrorMessage = "Username already exist";
                return View();
            }
            
        }
    }
}
