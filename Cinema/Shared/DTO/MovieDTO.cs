using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Shared.DTO
{
    public class MovieDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string AgeRating { get; set; }
        public string Trailer { get; set; }
    }
}
