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

        public Task AddMovie(MovieDTO movie)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDTO> GetMovie(int movieID)
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

        public async Task<List<MovieDTO>> GetMovies()
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

        public Task<IEnumerable<RoomDTO>> GetRooms()
        {
            throw new NotImplementedException();
        }

        public Task RemoveMovie(MovieDTO movie)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMovie(MovieDTO movie)
        {
            //MovieDTO oldMovie = await _context.Movies.Select(m => m).Where(m => m.ID == movie.ID);
            //oldMovie = movie;

            //await _context.SaveChangesAsync();
        }
    }
}
