namespace Cinema.Shared.DTO
{
    public class ConfirmBookingDTO
    {
        public BookingDTO BookingDTO { get; set; }
        public List<TicketTypeBookingDTO> TicketTypeBookingDTO { get; set; }
        public ScreeningDTO ScreeningDTO { get; set; }
        public string Email { get; set; }
        public string Movie { get; set; }
        public decimal Total { get; set; }
    }
}
