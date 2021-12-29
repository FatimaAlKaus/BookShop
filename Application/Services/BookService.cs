using Application.DTO;
using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IDbContext _context;

        public BookService(IDbContext context)
        {
            this._context = context;
        }
        public void AddBook(BookDto bookDto)
        {
            var authors = _context.Authors.FirstOrDefault(x => x.FullName.ToLower() == bookDto.Authors.ToLower()) ?? new Author()
            {
                FullName = bookDto.Authors,
                CreatedDate = DateTimeOffset.Now,
            };
            var genres = new List<Genre>();
            if (bookDto.GenresDto != null)
                genres = bookDto.GenresDto.Select(x => _context.Genres.FirstOrDefault(y => y.Id == x.Id)).ToList();
            Book book = new Book()
            {
                Title = bookDto.Title,
                CreatedDate = DateTimeOffset.Now,
                ImagePath = bookDto.ImagePath,
                Price = bookDto.Price,
                Authors = new List<Author>() { authors },
                Genres = genres,
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public bool BuyBook(int bookId, int userId)
        {
            var book = _context.Books.First(x => x.Id == bookId);
            var user = _context.Users.Include(x=>x.Books).First(x => x.Id == userId);
            if (user.Balance >= book.Price)
            {
                user.Balance -= book.Price;
                user.Books.Add(book);
                Order order = new Order()
                {
                    CreatedDate = DateTimeOffset.Now,
                    Book = book,
                    OrderPrice = book.Price,
                    User = user,
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
