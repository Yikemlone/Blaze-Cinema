namespace Cinema.Server.Models
{
    public class Screening
    {
        public int ID { get; set; }
        DateTime DateTime { get; set; }

        public int MmovieID { get; set; }
        public Movie Movie { get; set; }

        public int RoomID { get; set; }
        public Room Room { get; set; }

    }
}
