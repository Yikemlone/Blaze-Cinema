using Cinema.DataAccess.Services.RepositoryServices;
using Cinema.Models.Models;
using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.MovieServices
{
    public interface IMovieService : IRepository<MovieDTO>
    {
        //public Task<List<MovieDTO>> GetMoviesAsync();
        //public Task<MovieDTO> GetMovieAsync(int movieID);

        //// ADMIN METHODS
        //public Task CreateMovieAsync(MovieDTO movie);
        //public Task UpdateMovieAsync(MovieDTO movieID);
        //public Task DeleteMovieAsync(int movieID);
    }
}
