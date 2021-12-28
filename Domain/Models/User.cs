using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public int Balance { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
