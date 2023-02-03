using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Server.Models
{
    public class Schedule
    {
        public int ID { get; set; }

        public int RoomID { get; set; }
        public Room Room { get; set; }

        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        [Column(TypeName="Date")]
        public DateTime DateTime { get; set; }
    }
}
