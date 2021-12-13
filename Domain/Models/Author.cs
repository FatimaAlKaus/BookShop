using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Author : Entity
    {
        public string FullName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
