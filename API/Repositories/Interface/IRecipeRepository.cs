using API.Models;
using API.ViewModels;

namespace API.Repositories.Interface
{
    public interface IRecipeRepository : IGeneralRepository<Recipe, int>
    {
        int Recipe(RecipeVM recipeVM);
    }
}
