using Cinema.Models.Models;
using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.MovieService
{
    public interface IMovieService
    {
        public Task<List<MovieDTO>> GetMoviesAsync();
        public Task<MovieDTO> GetMovieAsync(int movieID);
        public Task<List<ScreeningDTO>> GetScreeningsAsync();
        public Task<ScreeningDTO> GetMovieScreeningAsync(int movieID);
        
    }
}
