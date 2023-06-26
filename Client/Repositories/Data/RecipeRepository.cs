using Client.Models;
using Client.Repositories.Interface;

namespace Client.Repositories.Data
{
    public class RecipeRepository : GeneralRepository<Recipe, int>, IRecipeRepository
    {
        public RecipeRepository(string request = "Recipe/") : base(request)
        {
            
        }
    }
}
