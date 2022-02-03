using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class DiscountBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal OldPrice { get; set; }
        public decimal ActualPrice => OldPrice * 0.9m;
        public string Authors { get; set; }
        public string Genres { get; set; }
        public List<GenreDto> GenresDto { get; set; }
        public string ImagePath { get; set; }
    }
}
