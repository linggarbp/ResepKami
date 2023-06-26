using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class IngredientController : GeneralController<IIngredientRepository, Ingredient, int>
    {
        public IngredientController(IIngredientRepository repository) : base(repository)
        {
        }
    }
}
