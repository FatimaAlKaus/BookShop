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

        public List<GenreDto> GetFavoriteGenres(int userId)
        {
            var user = _context.Users.Include(x => x.Books).ThenInclude(x => x.Genres).FirstOrDefault(x => x.Id == userId);
            var orderedGenres = user.Books.SelectMany(x => x.Genres).GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key);
            return orderedGenres.Select(x => new GenreDto() { Id = x.Id, Name = x.Name }).ToList();
        }
        public List<DiscountBookDto> OfferBooks(int userId, int take)
        {
            var user = _context.Users.Include(x => x.Books).FirstOrDefault(x => x.Id == userId);
            var genres = GetFavoriteGenres(userId);
            var unboughtBooks = _context.Books.Include(x => x.Genres).Include(x => x.Authors)
                .Where(x => !user.Books.Contains(x));
            return unboughtBooks.OrderByDescending(x => x.Genres.Where(y => genres.Select(z => z.Id).Contains(y.Id)).Count())
                .Select(x => new DiscountBookDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    OldPrice = x.Price,
                    Authors = String.Join(", ", x.Authors.Select(x => x.FullName)),
                    Genres = String.Join(", ", x.Genres),
                    ImagePath = x.ImagePath,
                }).Take(take).ToList();
        }
    }
}
