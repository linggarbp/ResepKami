using Client.Models;
using Client.Repositories.Interface;

namespace Client.Repositories.Data
{
    public class UserRoleRepository : GeneralRepository<UserRole, int>, IUserRoleRepository
    {
        public UserRoleRepository(string request = "UserRole/") : base(request)
        {
        }
    }

}
