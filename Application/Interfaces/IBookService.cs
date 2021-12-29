using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBookService
    {
        public void AddBook(BookDto bookDto);
        public bool BuyBook(int bookId, int userId);
    }
}
