namespace Cinema.Shared.DTO
{
    public class SeatScreeningDTO
    {
        public int ID { get; set; }
        public bool Booked { get; set; }
       
        public SeatDTO? Seat { get; set; }
        public int ScreeningID { get; set; }
        public int? BookingID { get; set; }
    }
}
