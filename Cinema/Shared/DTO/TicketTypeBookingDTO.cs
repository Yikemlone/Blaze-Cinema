using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Shared.DTO
{
    public class TicketTypeBookingDTO
    {
        public int ID { get; set; }

        public Guid BookingID { get; set; }
        public int TicketTypeID { get; set; } 
    }
}
