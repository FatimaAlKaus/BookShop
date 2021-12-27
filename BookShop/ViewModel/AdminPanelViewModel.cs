using Application.DTO;
using Application.Interfaces;
using BookShop.View.Dialogs;
using DevExpress.Mvvm;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookShop.ViewModel
{
    public class AdminPanelViewModel : BindableBase
    {
        private readonly IDbContext _context;
        private readonly IConfiguration _configuration;
        public List<BookDto> Books { get; set; }
        public List<GenreDto> Genres { get; set; }
        public AdminPanelViewModel(IDbContext context, IConfiguration configuration)
        {
            _context = context;
            Books = new List<BookDto>(_context.Books.Select(x => x.Adapt<BookDto>()));
            Genres = new List<GenreDto>(_context.Genres.Select(x => x.Adapt<GenreDto>()));
            _configuration = configuration;
        }
      
        public ICommand AddProduct => new DelegateCommand(() => 
        {
            NewProductDialog newProductDialog = new NewProductDialog();
            newProductDialog.ShowDialog();
        });
    }
}
