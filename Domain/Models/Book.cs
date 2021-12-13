using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public ICollection<Author> Authors { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
