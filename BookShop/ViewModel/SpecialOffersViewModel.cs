using Application.DTO;
using Application.Interfaces;
using DevExpress.Mvvm;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.ViewModel
{
    public class SpecialOffersViewModel : BindableBase
    {
        private readonly IDbContext _context;

        public SpecialOffersViewModel(IDbContext context)
        {
            _context = context;
        }
        public List<BookDto> Books => _context.Books.Include(x => x.Authors)
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
