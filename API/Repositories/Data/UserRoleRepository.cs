using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class UserRoleRepository : GeneralRepository<UserRole, int, MyContext>, IUserRoleRepository
{
    public UserRoleRepository(MyContext context) : base(context)
    {
    }

    public IEnumerable<string> GetRolesByEmail(string email)
    {
        var userId = _context.Users.FirstOrDefault(e => e.Email == email)!.Id;
        var userRoles = _context.UserRoles.Where(ur => ur.UserId == userId)
                                                .Join(_context.Roles, ar => ar.RoleId, r => r.Id, (ar, r) => new { ar, r })
                                                .Select(role => role.r.Name);
        return userRoles;
    }
}