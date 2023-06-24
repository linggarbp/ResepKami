using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : GeneralController<IRecipeRepository, Recipe, string>
    {
        public RecipeController(IRecipeRepository repository) : base(repository)
        {
        }
    }
}
