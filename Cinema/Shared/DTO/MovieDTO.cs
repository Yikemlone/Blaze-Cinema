namespace Cinema.Shared.DTO
{
    public class MovieDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Description { get; set; } = string.Empty;
        public string AgeRating { get; set; } = string.Empty;
        public string Trailer { get; set; } = string.Empty;

        public List<ScreeningDTO>? Screenings { get; set; }
    }
}

