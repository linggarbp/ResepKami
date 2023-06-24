using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : GeneralController<IIngredientRepository, Ingredient, string>
    {
        public IngredientController(IIngredientRepository repository) : base(repository)
        {
        }
    }
}
