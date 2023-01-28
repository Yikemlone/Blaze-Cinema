namespace Cinema.Server.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string AgeRating { get; set; }
        public string Trailer { get; set; }
        public string Image { get; set; } //If we name the PNG the title of the movie, we may not need this field
    }
}
