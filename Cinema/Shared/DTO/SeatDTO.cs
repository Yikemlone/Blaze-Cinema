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
        public string SeatNumber { get; set; } 
        public bool Booked { get; set; }
        public bool DisabiltySeat { get; set; }

        public int? RoomID { get; set; }
        public RoomDTO? Room { get; set; }

        //public List<SeatScreeningDTO>? SeatScreenings { get; set; }
    }
}
