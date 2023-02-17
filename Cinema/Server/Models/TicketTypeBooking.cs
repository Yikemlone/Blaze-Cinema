namespace Cinema.Server.Models
{
    public class TicketTypeBooking
    {
        public int ID { get; set; }

        public int BookingID { get; set; }
        public Booking Booking { get; set; }

        public int TicketTypeID { get; set; }
        public TicketType TicketType { get; set; }
    }
}
