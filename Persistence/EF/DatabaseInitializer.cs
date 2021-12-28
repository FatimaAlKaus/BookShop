using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF
{
    public static class DatabaseInitializer
    {
        public static void Initialize(IDbContext context)
        {
            var currentDate = DateTimeOffset.Now;
            var roles = new[]
            {
                new Role() { Name = Constants.Role.Admin, CreatedDate = currentDate } ,
                new Role() { Name = Constants.Role.Customer, CreatedDate = currentDate } ,
                new Role() { Name = Constants.Role.Guest, CreatedDate = currentDate } ,
            };
            context.Roles.AddRangeAsync(roles);
            context.Users.AddAsync(new Domain.Models.User()
            {
                Balance = 0,
                CreatedDate = currentDate,
                Role = roles[0],
                Password = "admin",
                UserName = "admin",
            });
            context.SaveChanges();
        }
    }
}
