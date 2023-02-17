using Cinema.Shared.DTO;

namespace Cinema.Server.Services.Movies
{
    public class MovieService : IMovieService
    {
        // This is the concrete implematntion of the IMovieService
        private readonly CinemaDBContext _context;

        public MovieService(CinemaDBContext context) 
        {
            _context = context;
        }

        public async Task AddMovieAsync(MovieDTO movie)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDTO> GetMovieAsync(int movieID)
        {
            var movie = _context.Movies
                 .Where(m => m.ID == movieID)
                 .Select(m => new MovieDTO()
                 {
                    ID = m.ID,
                    Name = m.Name,
                    AgeRating = m.AgeRating,
                    Duration = m.Duration,
                    Trailer = m.Trailer,
                    Description = m.Description
                 })
                 .SingleOrDefault();

            return movie;
        }

        public async Task<List<MovieDTO>> GetMoviesAsync()
        {
            List<MovieDTO> movies = _context.Movies
                .Select(m => new MovieDTO() 
                {
                    ID = m.ID,
                    Name = m.Name,
                    AgeRating = m.AgeRating,
                    Duration = m.Duration,
                    Trailer = m.Trailer,
                    Description = m.Description
                    
                }).ToList();

            return movies;
        }

        public async Task<List<RoomDTO>> GetRoomsAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveMovie(int movieID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMovieAsync(MovieDTO movie)
        {
            var oldMovie = _context.Movies
                 .Select(m => new MovieDTO()
                 {
                     ID = m.ID,
                     Name = m.Name,
                     AgeRating = m.AgeRating,
                     Duration = m.Duration,
                     Trailer = m.Trailer,
                     Description = m.Description
                 })
                 .Where(m => m.ID == movie.ID)
                 .SingleOrDefault();

            oldMovie = movie;

            await _context.SaveChangesAsync();
        }
    }
}
