using Cinema.Server.Models;
using Cinema.Shared.DTO;

namespace Cinema.Server.Services.Movies
{
    public interface IMovieService
    {
        // Example of GETs
        public Task<IEnumerable<MovieDTO>> GetMovies(); // We could use IQueryable to be more efficent
        public Task<IEnumerable<RoomDTO>> GetRooms();
        
        // Example of POSTs 
        public Task AddMovie(MovieDTO movie);
        public Task RemoveMovie(MovieDTO movie);
        
    }
}
