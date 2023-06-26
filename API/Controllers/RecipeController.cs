using API.Base;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecipeController : GeneralController<IRecipeRepository, Recipe, int>
    {
        public RecipeController(IRecipeRepository repository) : base(repository)
        {
        }

        [HttpPost("Recipe")]
        public ActionResult Recipe(RecipeVM recipeVM)
        {
            var recipe = _repository.Recipe(recipeVM);
            if (recipe > 0)
            {
                return Ok(new ResponseDataVM<string>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Insert Success"
                });
            }
            return BadRequest(new ResponseErrorVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Insert Failed / Lost Connection"
            });
        }

    }
}
