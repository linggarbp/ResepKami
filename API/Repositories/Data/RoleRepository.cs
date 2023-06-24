using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class RoleRepository : GeneralRepository<Role, string, MyContext>, IRoleRepository
{
    public RoleRepository(MyContext context) : base(context)
    {
    }
}