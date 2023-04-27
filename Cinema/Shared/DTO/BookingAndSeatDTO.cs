namespace Cinema.Shared.DTO
{
    public class BookingAndSeatDTO
    {
        public BookingDTO BookingDTO { get; set; }
        public List<TicketTypeBookingDTO> TicketTypeBookingDTO { get; set; }
    }
}
