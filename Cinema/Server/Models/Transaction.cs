namespace Cinema.Server.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; } // EX: Cancelled, refunded, pending, purchased

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
