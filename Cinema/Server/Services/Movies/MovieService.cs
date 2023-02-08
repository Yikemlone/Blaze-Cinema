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

        public Task<IEnumerable<MovieDTO>> GetMovies()
        {
            //var movies = _context.Movies.Select(m => m);
            //throw new NotImplementedException();
            throw new NotImplementedException();
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
