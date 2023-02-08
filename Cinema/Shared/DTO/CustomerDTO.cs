using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Shared.DTO
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Points { get; set; }

        //public List<Booking>? Bookings { get; set; } NOTE: This could be an issue if we can't import files from the server here.
        //public List<BookingDTO> Bookings { get; set; } NOTE: We could do this instead, if this works.
    }
}
