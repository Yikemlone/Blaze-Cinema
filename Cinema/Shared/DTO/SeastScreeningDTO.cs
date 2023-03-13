using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Shared.DTO
{
    public class SeastScreeningDTO
    {
        public int ID { get; set; }
        public bool Booked { get; set; }
        public int seatId { get; set; }
    }
}
