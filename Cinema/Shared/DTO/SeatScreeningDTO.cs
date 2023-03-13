using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Shared.DTO
{
    public class SeatScreeningDTO
    {
        public int ID { get; set; }
        public bool Booked { get; set; }
        public SeatDTO Seat { get; set; }
        public ScreeningDTO Screening { get; set; }
        public BookingDTO? Booking { get; set; }
    }
}
