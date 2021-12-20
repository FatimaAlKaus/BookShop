using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class BookDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Authors { get; set; }

        public string Genres { get; set; }
    }
}
