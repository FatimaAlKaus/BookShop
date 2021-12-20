using Application.DTO;
using Application.Interfaces;
using BookShop.View;
using DevExpress.Mvvm;
using Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookShop.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private readonly IDbContext _context;
        private readonly AdminPanelPage _adminPanelPage;
        private readonly BookListPage _bookListPage;

        public string Genres { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }

        public Page CurrentPage { get; set; }

        public ICommand AddBook => new DelegateCommand(() =>
        {
            var createdDate = DateTimeOffset.Now;
            var genres = Genres.Split(',').Select(x => new Genre() { Name = x.Trim(), CreatedDate = createdDate });
            var author = new Author() { FullName = Author, CreatedDate = createdDate };
            var book = new Book() { Authors = new List<Author>() { author }, CreatedDate = createdDate, Genres = new List<Genre>(genres), Price = Price, Title = Title };
            _context.Books.Add(book);
            _context.SaveChangesAsync();

        });
        public ICommand ToCatalog => new DelegateCommand(() => { CurrentPage = _bookListPage; });
        public ICommand ToAdmin => new DelegateCommand(() => { CurrentPage = _adminPanelPage; });
        public MainViewModel(IDbContext context, AdminPanelPage adminPanelPage, BookListPage bookListPage)
        {
            _context = context;
            _adminPanelPage = adminPanelPage;
            _bookListPage = bookListPage;
            CurrentPage = Ioc.Resolve<BookListPage>();
        }
    }
}
