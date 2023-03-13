namespace Cinema.Shared.DTO
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Points { get; set; }
        
        public List<BookingDTO>? Bookings { get; set; } 
    }
}
