using API.Models;
using API.ViewModels;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Text;

namespace Client2.Repositories
{
    public class ApprovalRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;

        public ApprovalRepository(string request = "Approval/")
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7214/api/")
            };
        }

        public async Task<ResponseDataVM<List<Approval>>> Get()
        {
            ResponseDataVM<List<Approval>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Approval>>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<string>> Put(int id, Approval approval)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(approval), Encoding.UTF8, "application/json");
            using (var response = httpClient.PutAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Approval>> Get(int id)
        {
            ResponseDataVM<Approval> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Approval>>(apiResponse);
            }
            return entity;
        }

        public async Task<ResponseDataVM<Approval>> Delete(int id)
        {
            ResponseDataVM<Approval> entity = null;

            using (var response = await httpClient.DeleteAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Approval>>(apiResponse);
            }
            return entity;
        }
    }
}
