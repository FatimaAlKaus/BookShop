using Application.DTO;
using Application.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
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

        public bool CheckUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public UserDto GetUserById(int id)
        {
            var model = _context.Users.Include(x => x.Role).Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            if (model is null)
                return null;
            return new UserDto() { Balance = model.Balance, Id = model.Id, UserName = model.UserName, Role = model.Role.Name };
        }

        public UserDto RegisterUser(UserDto user)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Name == "Customer");
            User model = new User()
            {
                CreatedDate = DateTimeOffset.UtcNow,
                UserName = user.UserName,
                Role = role,
                Balance = 0,
                Id = user.Id,
                Password = user.Password,
            };
            var entry = _context.Users.Add(model);
            _context.SaveChanges();
            return entry.Entity.Adapt<UserDto>();
        }
        public UserDto SignIn(string userName, string password)
        {
            var model = _context.Users.Include(x => x.Role).FirstOrDefault(x => x.UserName == userName && x.Password == password);
            if (model == null)
                return null;
            return new UserDto() { Role = model.Role.Name, UserName = model.UserName, Balance = model.Balance, Id = model.Id };

        }
    }
}
