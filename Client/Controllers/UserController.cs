using Client.Models;
using Client.Repositories.Data;
using Client.Repositories.Interface;
using Client.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var result = await repository.Login(login);
            if (result is null)
            {
                return RedirectToAction("Error", "Home");
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            else if (result.Code == 200)
            {
                HttpContext.Session.SetString("JWToken", result.Data);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/User/Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

            var result = await repository.Register(registerVM);
            if (result is null)
            {
                return RedirectToAction("Error", "Home");
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                TempData["Error"] = $"Something Went Wrong! - {result.Message}!";
                return View();
            }
            else if (result.Code == 200)
            {
                TempData["Success"] = $"Data has been Successfully Registered! - {result.Message}!";
                return RedirectToAction("Login", "User");
            }
            return View();
        }
    }
}
