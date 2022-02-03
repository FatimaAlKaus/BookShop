using Application.DTO;
using Application.Interfaces;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.ViewModel
{
    public class CartViewModel : BindableBase
    {
        private readonly IUserService _userService;
        private readonly IDbContext _context;

        public CartViewModel(IUserService userService, IDbContext context)
        {
            _userService = userService;
            _context = context;
        }
        public bool IsEmpty => Books.Count == 0;
        public List<BookDto> Books =>  _context.Books.Include(x => x.Authors)
                    .Where(x => _context.Users.Include(x => x.Books).FirstOrDefault(x => x.Id == EntireUser.Id).Books.Contains(x))
            .Select(x => new BookDto()
            {
                Authors = String.Join(",", x.Authors.Select(x => x.FullName)),
                Title = x.Title,
                Price = x.Price,
                Id = x.Id,
                ImagePath = x.ImagePath,
            }).ToList();

    }
}
