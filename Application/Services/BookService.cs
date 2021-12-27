using Application.DTO;
using Application.Interfaces;
using Domain.Models;
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
            var genres = bookDto.GenresDto.Select(x => _context.Genres.FirstOrDefault(y => y.Id == x.Id)).ToList();
            Book book = new Book()
            {
                Title = bookDto.Title,
                CreatedDate = DateTimeOffset.Now,
                ImagePath = bookDto.ImagePath,
                Price = bookDto.Price,
                Authors = new List<Author>() { authors },
                Genres=genres,
            };
            _context.Books.Add(book);
            _context.SaveChangesAsync();
        }
    }
}
