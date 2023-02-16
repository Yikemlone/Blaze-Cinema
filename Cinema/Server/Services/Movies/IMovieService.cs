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

        // Example of GETs service funtions 
        public Task<List<MovieDTO>> GetMoviesAsync();
        public Task<MovieDTO> GetMovieAsync(int movieID);

        //public Task<List<ScreeningDTO>> GetScreeningAsync();
        //public Task<List<ScreeningDTO>> GetMovieScrenningsAsync(int movieID);

        // Example of POSTs service funtions 

        // Admin Functions
        // Limit with authorization
        public Task AddMovieAsync(MovieDTO movie);
        public Task RemoveMovie(int movieID);
        public Task UpdateMovieAsync(MovieDTO movieID);

        // Manager Functions
        // Limit with authorization
        //public Task<ScreeningDTO> AddScreeningAsync(ScreeningDTO screening);
        //public Task DeleteScreeningAsync(int screeningID);
        //public Task EditScreeningAsync(ScreeningDTO screening);
        //public Task<List<RoomDTO>> GetRoomsAsync();
        //public Task UpdateRoom(RoomDTO roomDTO);

    }
}
