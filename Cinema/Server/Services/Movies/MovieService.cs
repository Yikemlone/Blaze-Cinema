using Cinema.Shared.DTO;

namespace Cinema.Server.Services.Movies
{
    public class MovieService : IMovieService
    {
        // This is the concrete implematntion of the IMovieService
        public Task AddMovie(MovieDTO movie)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieDTO>> GetMovies()
        {
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
    }
}
