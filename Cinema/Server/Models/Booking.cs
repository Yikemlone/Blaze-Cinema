using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Server.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public string Status { get; set; } // EX: Cancelled, refunded, pending, purchased
        public DateTime Time { get; set; } // This is gonna show us date and time, we could split this into two seperate coloums

        
        // All FK tables
        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public List<TicketType> TicketTypes { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
