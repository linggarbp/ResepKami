using API.Models;
using API.ViewModels;
using Client2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
public class UserController : Controller
{
    private readonly UserRepository repository;

    public UserController(UserRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM login)
    {
        var result = await repository.Login(login);
        if (result.Code == 200)
        {
            HttpContext.Session.SetString("JWToken", result.Data);
            return RedirectToAction("index", "home");
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(User user)
    {

        var result = await repository.Post(user);
        if (result.Code == 200)
        {
            TempData["Success"] = "Insert Data Success";
            return RedirectToAction("login", "user");
        }
        else if (result.Code == 409)
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }

        return View();
    }

    public async Task<IActionResult> Index()
    {
        var results = await repository.Get();
        var users = new List<User>();

        if (results != null)
        {
            users = results.Data.ToList();
        }

        return View(users);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(User account)
    {

        var result = await repository.Post(account);
        if (result.Code == 200)
        {
            TempData["Success"] = "Data berhasil masuk";
            return RedirectToAction(nameof(Index));
        }
        else if (result.Code == 409)
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var Results = await repository.Get(id);
        return View(Results.Data);
    }
}