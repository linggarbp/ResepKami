using API.Models;

namespace API.Repositories.Interface;

public interface IUserRoleRepository : IGeneralRepository<UserRole, int>
{
    IEnumerable<string> GetRolesByEmail(string email);
}
