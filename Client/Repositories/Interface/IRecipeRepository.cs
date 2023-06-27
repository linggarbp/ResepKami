using Client.Models;
using Client.ViewModels;

namespace Client.Repositories.Interface
{
    public interface IRecipeRepository : IGeneralRepository<Recipe, int>
    {
        public Task<ResponseMessageVM> Recipe(RecipeVM entity);
    }
}
