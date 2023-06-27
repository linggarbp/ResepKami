using API.Models;
using API.ViewModels;

namespace API.Repositories.Interface
{
    public interface IUserRepository : IGeneralRepository<User, int>
    {
        int Register(RegisterVM registerVM);
        bool Login(LoginVM loginVM);
    }
}
