using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public static class BookMapper
    {
        public static BookDto AdaptToDto(this Book book)
        {
            return book == null ? null : new BookDto()
            {
                Authors = string.Join(", ", book.Authors.Select(x => x.FullName)),
                Title = book.Title,
                Genres = string.Join(", ", book.Genres.Select(x => x.Name)),
                ImagePath = book.ImagePath,
                Price = book.Price,
            };
        }
    }
}
