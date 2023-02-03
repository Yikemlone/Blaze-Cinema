using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Server.Models
{
    public class Booking
    {
        public int ID { get; set; }

        // All FK tables
        public int RoomID { get; set; }
        public Room Room { get; set; }

        public int SeatID { get; set; }
        public Seat Seat { get; set; }

        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        [Column(TypeName="Date")]
        public DateTime Time { get; set; } // This is gonna show us date and time, we could split this into two seperate coloums
    }
}
