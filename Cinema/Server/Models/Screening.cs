namespace Cinema.Server.Models
{
    public class Screening
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }

        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        public int RoomID { get; set; }
        public Room Room { get; set; }

    }
}
