using Application.DTO;
using Application.Interfaces;
using DevExpress.Mvvm;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Persistence.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookShop.ViewModel
{
    public class BookCatalogViewModel : BindableBase
    {
        private readonly IDbContext _context;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly string[] _sortingTypes = new string[] { "Дате", "Цене", "Названию" };

        private bool _isDescending;

        public event Action OnPurchased;
        public bool IsDescending { get => _isDescending; set { _isDescending = value; RaisePropertyChanged("Books"); } }
        public int SelectedIndex { get; set; }
        public BookCatalogViewModel(IDbContext context, IBookService bookService, IUserService userService)
        {
            _context = context;
            _userService = userService;
            _bookService = bookService;
        }
        public string SearchString { get => _searchString; set { _searchString = value; RaisePropertyChanged("Books"); } }
        public string[] SortingTypes => _sortingTypes;
        private string _searchString = "";
        public List<BookDto> Books
        {
            get
            {
                var books = _context.Books.Include(x => x.Authors)
                    .Where(x => !_context.Users.Include(x => x.Books).FirstOrDefault(x => x.Id == EntireUser.Id).Books.Contains(x))
                      .Where(x =>
                         x.Title.Contains(SearchString) ||
                         x.Authors.Any(a => a.FullName.Contains(SearchString)));
                switch (SelectedIndex)
                {
                    case 0:
                        books = IsDescending ? books.OrderBy(x => x.CreatedDate) : books.OrderByDescending(x => x.CreatedDate);
                        break;
                    case 1:
                        books = IsDescending ? books.OrderBy(x => x.Price) : books.OrderByDescending(x => x.Price);
                        break;
                    case 2:
                        books = IsDescending ? books.OrderBy(x => x.Title) : books.OrderByDescending(x => x.Title);
                        break;
                }
                var result = new List<BookDto>();
                foreach(var x in books)
                {
                    result.Add(new BookDto()
                    {
                        Authors = String.Join(",", x.Authors.Select(x => x.FullName)),
                        Title = x.Title,
                        Price = x.Price,
                        Id = x.Id,
                        ImagePath = x.ImagePath,
                        IsNew = DateTimeOffset.Now < x.CreatedDate.AddSeconds(30),
                    });
                }
              
                return result;
            }
        }
        public ICommand Buy => new DelegateCommand<int>((bookId) =>
        {
            if (_userService.GetUserById(EntireUser.Id).Role == Role.Customer && _bookService.BuyBook(bookId, EntireUser.Id))
            {
                RaisePropertyChanged("Books");
            }
            else
            {
                MessageBox.Show("Мало денег");
            }
        });
    }
}
