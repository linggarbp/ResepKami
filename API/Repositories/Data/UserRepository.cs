using API.Context;
using API.Handler;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;

namespace API.Repositories.Data
{
    public class UserRepository : GeneralRepository<User, int, MyContext>, IUserRepository
    {
        public UserRepository(MyContext context) : base(context)
        {
        }

        public int Register(RegisterVM registerVM)
        {
            int result = 0;
            // Insert to User Table
            var user = new User
            {
                Id = registerVM.Id,
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                Password = Hashing.HashPassword(registerVM.Password)
            };
            _context.Set<User>().Add(user);
            result += _context.SaveChanges();

            // Insert to UserRole Table
            var userRole = new UserRole
            {
                UserId = registerVM.Id,
                RoleId = 1
            };
            _context.Set<UserRole>().Add(userRole);
            result += _context.SaveChanges();

            return result;
        }

        public bool Login(LoginVM loginVM)
        {
            var getUser = _context.Users.FirstOrDefault(e => e.Email == loginVM.Email);

            if (getUser == null)
                return false;

            return Hashing.ValidatePassword(loginVM.Password, getUser.Password);
        }
    }
}
