namespace Cinema.Shared.DTO
{
    public class BookingDTO
    {
        public int ID { get; set; }
        public string Status { get; set; } = string.Empty;

        public List<SeatDTO> Seats { get; set; } = new();
        public List<TicketTypeDTO> TicketTypes { get; set; } = new();
        public CustomerDTO? Customer { get; set; }

    }
}
