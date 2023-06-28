using Client.Models;
using Client.Repositories.Data;
using Client.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository repository;

        public RecipeController(IRecipeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var results = await repository.Get();
            var recipes = new List<Recipe>();

            if (results != null)
            {
                recipes = results.Data.ToList();
            }

            return View(recipes);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.Post(recipe);
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
            var Results = await repository.Get(id);
            return View(Results.Data);

            //var result = await repository.Get(id);
            //var recipe = new Recipe();
            //if (result.Data?.Id is null)
            //{
            //    return View(recipe);
            //}
            //else
            //{
            //    return View(result.Data);
            //}
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Recipe recipe, int id)
        {
            var result = await repository.Put(recipe, id);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil diubah";
                return RedirectToAction(nameof(Index));
            }
            else if (result.Code == 404)
            {
                TempData["Success"] = "Data tidak ditemukan";
                return RedirectToAction(nameof(Index));
            }

            return View();

            //if (ModelState.IsValid)
            //{
            //    var result = await repository.Put(university.Id, university);
            //    if (result.StatusCode == "200")
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    else if (result.StatusCode == "409")
            //    {
            //        ModelState.AddModelError(string.Empty, result.Message);
            //        return View();
            //    }
            //}
            //return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var Results = await repository.Get(id);
            return View(Results.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Recipe recipe)
        {
            var result = await repository.Delete(id);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }
            else if (result.Code == 404)
            {
                TempData["Success"] = "Data tidak ditemukan";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
