using Cinema.Server.Models;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Cinema.Server.Services.Movies
{
    public interface IMovieService
    {
        public Task<List<MovieDTO>> GetMoviesAsync();
        public Task<MovieDTO> GetMovieAsync(int movieID);
        public Task<List<ScreeningDTO>> GetScreeningsAsync();
        public Task<ScreeningDTO> GetMovieScreeningAsync(int movieID);
        
    }
}
