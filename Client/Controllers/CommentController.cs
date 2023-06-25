using Client.Models;
using Client.Repositories.Data;
using Client.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository repository;

        public CommentController(ICommentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var results = await repository.Get();
            var comments = new List<Comment>();

            if (results.Data != null)
            {
                comments = results.Data.ToList();
            }

            return View(comments);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.Post(comment);
                if (result.StatusCode == "200")
                {
                    TempData["Success"] = "Data berhasil masuk";
                    return RedirectToAction(nameof(Index));
                }
                else if (result.StatusCode == "409")
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
        public async Task<IActionResult> Edit(int id, Comment comment)
        {
            var result = await repository.Put(id, comment);
            if (result.StatusCode == "200")
            {
                TempData["Success"] = "Data berhasil diubah";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == "404")
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
        public async Task<IActionResult> Delete(int id, Comment comment)
        {
            var result = await repository.Delete(id);
            if (result.StatusCode == "200")
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == "404")
            {
                TempData["Success"] = "Data tidak ditemukan";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}