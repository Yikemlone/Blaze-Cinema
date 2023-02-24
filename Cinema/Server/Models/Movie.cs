namespace Cinema.Server.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string AgeRating { get; set; }
        public string Description { get; set; }
        public string Trailer { get; set; }

        public List<Screening>? Screenings { get; set; }
    }
}
