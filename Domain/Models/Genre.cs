using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Genre : Entity
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
