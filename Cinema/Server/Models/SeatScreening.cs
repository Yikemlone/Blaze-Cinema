namespace Cinema.Server.Models
{
    public class SeatScreening
    {
        public int ID { get; set; }
        public bool Booked { get; set; }

        public int SeatID { get; set; }
        public Seat Seat { get; set; }

        public int? BookingID { get; set; } // NEED TO UPDATE CLASS DIAGRAM FOR 0.1 relationship
        public Booking? Booking { get; set; }

        public int ScreeningID { get; set; }
        public Screening Screening { get; set; }
    }
}
