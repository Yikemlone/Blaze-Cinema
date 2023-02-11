namespace Cinema.Server.Models
{
    public class Seat
    {
        public int ID { get; set; }
        public string SeatNumber { get; set; } // We may need this becuase of seat row and colum
        public bool Booked { get; set; }
        public bool DisabiltySeat { get; set; }

        // FK to Room class
        public int BookingID { get; set; }
        public Booking Booking { get; set; }

        public int ScreeningID { get; set; }
        public Screening Screening { get; set; }
    }
}
