using Client.Models;
using Client.Repositories.Interface;
using Client.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories.Data
{
    public class UserRepository : GeneralRepository<User, int>, IUserRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;

        public UserRepository(string request = "User/") : base(request)
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7214/api/")
            };
        }

        public async Task<ResponseViewModel<string>> Login(LoginVM entity)
        {
            ResponseViewModel<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "Login", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseViewModel<string>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseMessageVM> Register(RegisterVM entity)
        {
            ResponseMessageVM entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "Register", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseMessageVM>(apiResponse);
            }
            return entityVM;
        }
    }
}
