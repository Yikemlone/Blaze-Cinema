using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Shared.DTO
{
    public class SeatDTO
    {
        public int ID { get; set; }
        public string SeatNumber { get; set; } // We may need this becuase of seat row and colum
        public bool Booked { get; set; }
        public bool DisabiltySeat { get; set; }
        public RoomDTO Room { get; set; }
    }
}
