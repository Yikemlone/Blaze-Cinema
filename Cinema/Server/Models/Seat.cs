namespace Cinema.Server.Models
{
    public class Seat
    {
        public int ID { get; set; }
        public string SeatNumber { get; set; } // We may need this becuase of seat row and colum
        public bool Booked { get; set; } // Check at some point if the screening that is attached to this seat is over or not
        public bool DisabiltySeat { get; set; }

        // FK to Room class
        public int BookingID { get; set; }
        public Booking Booking { get; set; }

        public int ScreeningID { get; set; }
        public Screening Screening { get; set; }
    }
}
