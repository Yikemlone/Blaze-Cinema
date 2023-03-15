namespace Cinema.Models.Models
{
    public class Room
    {
        public int ID { get; set; }
        public bool Decom { get; set; }

        public List<Screening>? Screenings { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
