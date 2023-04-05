namespace Cinema.Models.Models
{
    public class TicketTypeBooking
    {
        public int ID { get; set; }

        public Guid BookingID { get; set; }
        public Booking Booking { get; set; }

        public int TicketTypeID { get; set; }
        public TicketType TicketType { get; set; }
    }
}
