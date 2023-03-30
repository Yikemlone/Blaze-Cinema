using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Shared.DTO
{
    public class BookingAndSeatDTO
    {
        public BookingDTO BookingDTO { get; set; }
        public List<TicketTypeBookingDTO> TicketTypeBookingDTO { get; set; }
    }
}
