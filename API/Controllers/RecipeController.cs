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
    
    public class RecipeController : GeneralController<IRecipeRepository, Recipe, int>
    {
        //private readonly IRequestRepository _requestRepository;

        public RecipeController(IRecipeRepository repository/*, IRequestRepository requestRepository*/) : base(repository)
        {
            //_requestRepository = requestRepository;
        }

        //[HttpGet]
        //public ActionResult GetApproveRecipe()
        //{
        //    var results = _requestRepository.GetApproveRecipe();
        //    if (results == null)
        //        return NotFound(new ResponseErrorVM<string>
        //        {
        //            Code = StatusCodes.Status404NotFound,
        //            Status = HttpStatusCode.NotFound.ToString(),
        //            Errors = "Data not Found"
        //        });

        //    return Ok(new ResponseDataVM<IEnumerable<int>>
        //    {
        //        Code = StatusCodes.Status200OK,
        //        Status = HttpStatusCode.OK.ToString(),
        //        Message = "Success",
        //        Data = results
        //    });
        //}

        //[Authorize]
        [HttpPost("AddRecipe")]
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
