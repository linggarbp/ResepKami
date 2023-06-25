using Client.Models;
using Client.Repositories.Interface;

namespace Client.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(string request = "Role/") : base(request)
        {
            
        }
    }
}
