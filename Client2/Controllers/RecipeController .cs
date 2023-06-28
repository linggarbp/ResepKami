using API.Models;
using API.ViewModels;
using Client2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize]
public class RecipeController : Controller
{
    private readonly RecipeRepository repository;

    public RecipeController(RecipeRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var Results = await repository.Get();
        var universities = new List<Recipe>();

        if (Results != null)
        {
            universities = Results.Data.ToList();
        }

        return View(universities);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(RecipeVM recipe)
    {

        var result = await repository.Recipe(recipe);
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

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var results = await repository.Get(id);
        var recipes = new Recipe();

        if (results.Data?.Id is null)
        {
            return View(recipes);
        }
        else
        {
            recipes.Id = results.Data.Id;
            recipes.RecipeName =results.Data.RecipeName;
            recipes.Description =results.Data.Description;
            recipes.IngredientName =results.Data.IngredientName;
            recipes.Total =results.Data.Total;
            recipes.Step =results.Data.Step;
            recipes.CookingTime =results.Data.CookingTime;
            recipes.Difficulty =results.Data.Difficulty;
        }
        return View(recipes);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Recipe recipe)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(recipe.Id, recipe);
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
        var university = result?.Data;

        return View(university);
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