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
    public class AdminPanelViewModel : BindableBase
    {
        private readonly IDbContext _context;

        public List<BookDto> Books { get; set; }
        public AdminPanelViewModel(IDbContext context)
        {
            _context = context;
            Books = new List<BookDto>(_context.Books.Select(x => x.Adapt<BookDto>()));
        }
    }
}
