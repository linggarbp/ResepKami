using Client.Models;
using Client.ViewModels;

namespace Client.Repositories.Interface
{
    public interface IUserRepository : IGeneralRepository<User, string>
    {
        public Task<ResponseViewModel<string>> Login(LoginVM entity);
        public Task<ResponseMessageVM> Register(RegisterVM entity);
    }
}
