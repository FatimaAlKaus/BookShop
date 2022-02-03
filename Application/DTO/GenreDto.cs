using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; } = false;
        public override string ToString()
        {
            return Name;
        }
    }
}
