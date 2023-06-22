using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Client.ViewModels;
using Newtonsoft.Json;

namespace Client.Repositories
{
    public class GeneralRepository<TEntity, TKey> : IGeneralRepository<TEntity, TKey>
    where TEntity : class
    {
        private readonly string request;
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor contextAccessor;

        public GeneralRepository(string request)
        {
            this.request = request;
            contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7214/api/")
            };
            // Ini yg bawah skip dulu
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", contextAccessor.HttpContext?.Session.GetString("JWToken"));
        }

        public Task<ResponseMessageVM> Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseListVM<TEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseViewModel<TEntity>> Get(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessageVM> Post(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessageVM> Put(TEntity entity, TKey id)
        {
            throw new NotImplementedException();
        }
    }
}
