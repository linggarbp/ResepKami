using API.Base;
using API.Handlers;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GeneralController<IUserRepository, User, string>
    {
        private readonly ITokenService _tokenService;
        //private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserController(IUserRepository repository, ITokenService tokenService, /*IUserRepository userRepository,*/ IUserRoleRepository userRoleRepository) : base(repository)
        {
            _tokenService = tokenService;
            //_userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var register = _repository.Register(registerVM);
            if (register > 0)
            {
                return Ok(new ResponseDataVM<string>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Insert Success"
                });
            }
            return BadRequest(new ResponseErrorVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Insert Failed / Lost Connection"
            });
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = _repository.Login(loginVM);
            if (login)
            {
                var claims = new List<Claim>()
            {
                new Claim("Email", loginVM.Email),
                new Claim("UserName", loginVM.Email)
            };

                var getRoles = _userRoleRepository.GetRolesByEmail(loginVM.Email);
                foreach (var role in getRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var token = _tokenService.GenerateToken(claims);

                return Ok(new ResponseDataVM<string>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Login Success",
                    Data = token
                });
            }
            return NotFound(new ResponseErrorVM<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Login Failed, Email or Password Not Found"
            });
        }
    }
}

