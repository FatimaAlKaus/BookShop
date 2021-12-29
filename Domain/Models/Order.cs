using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order : Entity
    {
        public User User { get; set; }

        public Book Book { get; set; }

        public decimal OrderPrice { get; set; }
    }
}
