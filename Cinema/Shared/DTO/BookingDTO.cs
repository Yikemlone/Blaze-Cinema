namespace Cinema.Shared.DTO
{
    public class BookingDTO
    {
        public int ID { get; set; }
        public string Status { get; set; } = string.Empty;

        public List<SeatScreeningDTO> SeatScreenings { get; set; } = new();
        public List<TicketTypeDTO> TicketTypes { get; set; } = new();

        public int? CustomerID { get; set; }
        public CustomerDTO? Customer { get; set; }

    }
}
