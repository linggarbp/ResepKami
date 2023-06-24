using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class RecipeRepository : GeneralRepository<Recipe, string, MyContext>, IRecipeRepository
{
    public RecipeRepository(MyContext context) : base(context)
    {
    }
}