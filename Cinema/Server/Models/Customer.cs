namespace Cinema.Server.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Points { get; set; }

        public List<Booking>? Bookings { get; set; }
    }
}
