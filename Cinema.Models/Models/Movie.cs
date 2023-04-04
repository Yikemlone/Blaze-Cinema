namespace Cinema.Models.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string AgeRating { get; set; }
        public string Description { get; set; }
        public string Trailer { get; set; }
        public DateTime? ReleaseDate { get; set; } // Does this need to be nullable??

        public List<Screening>? Screenings { get; set; }
    }
}
