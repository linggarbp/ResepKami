using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : GeneralController<IUserRoleRepository, UserRole, int>
    {
        public UserRoleController(IUserRoleRepository repository) : base(repository)
        {
        }
    }
}
