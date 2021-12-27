using Application.DTO;
using Application.Interfaces;
using Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContext _context;

        public UserService(IDbContext context)
        {
            this._context = context;
        }
        public UserDto RegisterUser(UserDto user)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Name == "Customer");
            User model = new User()
            {
                CreatedDate = DateTimeOffset.UtcNow,
                UserName = user.UserName,
                Role = role,
                Email = "kek",
                Password = user.Password.GetHashCode().ToString(),
            };
            var entry = _context.Users.Add(model);
            _context.SaveChangesAsync();
            return entry.Entity.Adapt<UserDto>();
        }
        public UserDto SignIn(string userName, string password)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password.GetHashCode().ToString()).Adapt<UserDto>();

        }
    }
}
