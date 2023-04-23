using Cinema.DataAccess.Services.RepositoryServices;
using Cinema.Models.Models;
using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.MovieServices
{
    public interface IMovieService 
    {
        public Task<List<MovieDTO>> GetAllAsync();
        public Task<MovieDTO> GetAsync(int movieID);

        // ADMIN METHODS
        public Task<int> AddAsync(MovieDTO movie);
        public Task UpdateAsync(MovieDTO movieID);
        public Task DeleteAsync(MovieDTO movieID);
    }
}
