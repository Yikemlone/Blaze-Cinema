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
        public Task<List<MovieDTO>> GetMoviesAsync(); // We could use IQueryable to be more efficent
        public Task<IEnumerable<RoomDTO>> GetRoomsAsync();
        public Task<MovieDTO> GetMovieAsync(int movieID);
        //public Task<List<ScreeningDTO>> GetScreeningAsync();


        // Example of POSTs 
        // We can limit these functions with authorization, hopefully
        public Task AddMovieAsync(MovieDTO movie);
        public Task RemoveMovie(MovieDTO movie);
        public Task UpdateMovieAsync(MovieDTO movie);
        
    }
}
