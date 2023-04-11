namespace Cinema.Shared.DTO
{
    public class TicketTypeDTO
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
