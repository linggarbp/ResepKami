using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class IngredientRepository : GeneralRepository<Ingredient, string, MyContext>, IIngredientRepository
{
    public IngredientRepository(MyContext context) : base(context)
    {
    }
}