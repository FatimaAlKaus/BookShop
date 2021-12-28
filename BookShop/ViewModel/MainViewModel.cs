using Application.DTO;
using Application.Interfaces;
using BookShop.View;
using BookShop.View.Dialogs;
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
        private readonly CartPage _cartPage;
        public bool IsAuthorized => CurrentUser.Role != Persistence.Constants.Role.Guest;
        public bool IsAdmin => CurrentUser.Role == Persistence.Constants.Role.Admin;
        public UserDto CurrentUser { get; set; }
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
        public ICommand ToCart => new DelegateCommand(() => { CurrentPage = _cartPage; });

        public ICommand Register => new DelegateCommand(() =>
        {
            var registrationDialog = Ioc.Resolve<RegisterDialog>();
            registrationDialog.ShowDialog();
            CurrentUser = new UserDto() { UserName = BookShop.CurrentUser.Name, Role = BookShop.CurrentUser.Role };
            RaisePropertyChanged("IsAuthorized");
            RaisePropertyChanged("IsAdmin");
        });
        public ICommand SignIn => new DelegateCommand(() =>
        {
            var signInDialog = Ioc.Resolve<AuthorizeWindow>();
            signInDialog.ShowDialog();
            CurrentUser = new UserDto() { UserName = BookShop.CurrentUser.Name, Role = BookShop.CurrentUser.Role, Balance = BookShop.CurrentUser.Balance };
            RaisePropertyChanged("IsAuthorized");
            RaisePropertyChanged("IsAdmin");
        });
        public ICommand SignOut => new DelegateCommand(() =>
        {
            BookShop.CurrentUser.SignOut();
            CurrentUser = new UserDto() { UserName = BookShop.CurrentUser.Name, Role = BookShop.CurrentUser.Role };
            if (CurrentPage == _adminPanelPage)
            {
                CurrentPage = null;
            }
            RaisePropertyChanged("IsAuthorized");
            RaisePropertyChanged("IsAdmin");
        }, () => IsAuthorized);
        public MainViewModel(
            IDbContext context,
            AdminPanelPage adminPanelPage,
            BookListPage bookListPage,
            CartPage cartPage)
        {
            _context = context;
            _adminPanelPage = adminPanelPage;
            _bookListPage = bookListPage;
            _cartPage = cartPage;
            CurrentPage = _bookListPage;
            CurrentUser = new UserDto() { UserName = BookShop.CurrentUser.Name, Role = BookShop.CurrentUser.Role };
        }
    }
}
