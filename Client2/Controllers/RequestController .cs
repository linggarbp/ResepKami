using API.Models;
using API.ViewModels;
using Client2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize]
public class RequestController : Controller
{
    private readonly RequestRepository repository;

    public RequestController(RequestRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var results = await repository.Get();
        var requests = new List<Request>();

        if (results != null)
        {
            requests = results.Data.ToList();
        }

        return View(requests);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var results = await repository.Get(id);
        return View(results.Data);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await repository.Get(id);
        var request = new Request();

        if (result.Data?.Id is null)
        {
            return View(request);
        }
        else
        {
            request.Id = result.Data.Id;
            request.RecipeId = result.Data.RecipeId;
            request.RecipeName = result.Data.RecipeName;
            request.IsApproved = result.Data.IsApproved;
        }
        return View(request);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Request req)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(req.Id, req);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(Index));
            }
            else if (result.Code == 500)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await repository.Get(id);
        var request = result?.Data;

        return View(request);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        var result = await repository.Delete(id);
        if (result.Code == 200)
        {
            TempData["Success"] = "Delete Data Success";
            return RedirectToAction(nameof(Index));
        }

        var university = await repository.Get(id);
        return View("Delete", university?.Data);
    }
}