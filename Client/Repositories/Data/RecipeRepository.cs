using Client.Models;
using Client.Repositories.Interface;
using Client.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories.Data
{
    [Authorize]
    public class RecipeRepository : GeneralRepository<Recipe, int>, IRecipeRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;

        public RecipeRepository(string request = "Recipes/") : base(request)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7214/api/")
            };
            this.request = request;
        }

        public async Task<ResponseMessageVM> Recipe(RecipeVM entity)
        {
            ResponseMessageVM entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "Recipe", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseMessageVM>(apiResponse);
            }
            return entityVM;
        }
    }
}
