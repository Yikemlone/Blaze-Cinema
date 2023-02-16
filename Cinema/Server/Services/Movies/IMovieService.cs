using Cinema.Server.Models;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Cinema.Server.Services.Movies
{
    public interface IMovieService
    {

        // This class can be scoped to the whole project. For example, we could allow for employee data and customer data to be
        // returend from this service, or we seperate those into a customer and employee service OR a Person service that can handle
        // similar information and we will use inhertance to seperate it out.

        // Example of GETs
        public Task<List<MovieDTO>> GetMovies(); // We could use IQueryable to be more efficent
        public Task<IEnumerable<RoomDTO>> GetRooms();
        public Task<MovieDTO> GetMovie(int movieID);


        // Example of POSTs 
        // We can limit these functions with authorization, hopefully
        public Task AddMovie(MovieDTO movie);
        public Task RemoveMovie(MovieDTO movie);
        public Task UpdateMovie(MovieDTO movie);
        
    }
}
