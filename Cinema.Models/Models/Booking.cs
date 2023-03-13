using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public string Status { get; set; }


        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public List<TicketTypeBooking> TicketTypeBookings { get; set; } // Fix this in class diagram
        public List<SeatScreening> SeatScreenings { get; set; }

    }
}
