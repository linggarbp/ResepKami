using Client.Models;
using Client.Repositories.Interface;

namespace Client.Repositories.Data
{
    public class IngredientRepository : GeneralRepository<Ingredient, int>, IIngredientRepository
    {
        public IngredientRepository(string request = "Ingredient/") : base(request)
        {
            
        }
    }
}
