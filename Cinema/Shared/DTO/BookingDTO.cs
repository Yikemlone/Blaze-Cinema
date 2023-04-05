namespace Cinema.Shared.DTO
{
    public class BookingDTO
    {
        public Guid ID { get; set; }
        public string BookingRef { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public int? CustomerID { get; set; }
        public CustomerDTO? Customer { get; set; }

        public List<SeatScreeningDTO> SeatScreenings { get; set; } = new();
        public List<TicketTypeDTO> TicketTypes { get; set; } = new();

    }
}
