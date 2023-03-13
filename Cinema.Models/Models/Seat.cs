namespace Cinema.Models.Models
{
    public class Seat
    {
        public int ID { get; set; }
        public string SeatNumber { get; set; }
        public bool DisabiltySeat { get; set; }

        public int? RoomID { get; set; }
        public Room? Room { get; set; }

        public List<SeatScreening>? SeatScreenings { get; set; }
    }
}
