using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Server.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public string Status { get; set; } // Cancelled, Refunded, Pending, Confirmed
        public DateTime Time { get; set; } 

        // All FK tables
        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public List<TicketType> TicketTypes { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
