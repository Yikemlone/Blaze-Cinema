using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.AdminService
{
    public interface IAdminService
    {
        // Admin Functions
        // Limit with authorization
        public Task CreateMovieAsync(MovieDTO movie);
        public Task UpdateMovieAsync(MovieDTO movieID);
        public Task DeleteMovieAsync(int movieID);
    }
}
