using API.Models;
using API.ViewModels;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Text;

namespace Client2.Repositories
{
    public class RequestRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;

        public RequestRepository(string request = "Recipe/")
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7214/api/")
            };
        }

        public async Task<ResponseDataVM<List<Request>>> Get()
        {
            ResponseDataVM<List<Request>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Request>>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<string>> Put(int id, Request req)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            using (var response = httpClient.PutAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Request>> Get(int id)
        {
            ResponseDataVM<Request> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Request>>(apiResponse);
            }
            return entity;
        }

        public async Task<ResponseDataVM<Request>> Delete(int id)
        {
            ResponseDataVM<Request> entity = null;

            using (var response = await httpClient.DeleteAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Request>>(apiResponse);
            }
            return entity;
        }
    }
}
