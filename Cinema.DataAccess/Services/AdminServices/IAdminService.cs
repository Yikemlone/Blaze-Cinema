using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.AdminServices
{
    public interface IAdminService
    {
        // Admin Functions
        // Limit with authorization
        public Task<int> CreateMovieAsync(MovieDTO movie);
        public Task UpdateMovieAsync(MovieDTO movieID);
        public Task DeleteMovieAsync(int movieID);
    }
}
