namespace Cinema.Server.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; } // We may need this becuase of seat row and colum
        public bool booked { get; set; }
        public bool disabiltySeat { get; set; }

        // FK to Room class
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
