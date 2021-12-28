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
    public class BookCatalogViewModel : BindableBase
    {
        private readonly IDbContext _context;

        public BookCatalogViewModel(IDbContext context)
        {
            _context = context;
            //Books = _context.Books.Select(x => x.Adapt<BookDto>()).ToList();
        }
        public string SearchString { get => _searchString; set { _searchString = value; RaisePropertyChanged("Books"); } }
        private string _searchString = "";
        public List<BookDto> Books => _context.Books.Include(x => x.Authors).Where(x =>
            x.Title.Contains(SearchString) ||
            x.Authors.Any(a => a.FullName.Contains(SearchString))

            ).Select(x => new BookDto()
            {
                Authors = String.Join(",", x.Authors.Select(x => x.FullName)),
                Title = x.Title,
                Price = x.Price,
                ImagePath = x.ImagePath,
            }).ToList();
    }
}
