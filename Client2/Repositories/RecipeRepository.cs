using API.Models;
using API.ViewModels;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Text;

namespace Client2.Repositories
{
    public class RecipeRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;

        public RecipeRepository(string request = "Recipe/")
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7214/api/")
            };
        }

        public async Task<ResponseDataVM<string>> Recipe(RecipeVM recipe)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(recipe), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "AddRecipe", content).Result) //localhost/api/university {method:post} -> content
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<List<Recipe>>> Get()
        {
            ResponseDataVM<List<Recipe>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Recipe>>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<string>> Put(int id, Recipe recipe)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(recipe), Encoding.UTF8, "application/json");
            using (var response = httpClient.PutAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Recipe>> Get(int id)
        {
            ResponseDataVM<Recipe> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Recipe>>(apiResponse);
            }
            return entity;
        }

        public async Task<ResponseDataVM<Recipe>> Delete(int id)
        {
            ResponseDataVM<Recipe> entity = null;

            using (var response = await httpClient.DeleteAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Recipe>>(apiResponse);
            }
            return entity;
        }
    }
}
