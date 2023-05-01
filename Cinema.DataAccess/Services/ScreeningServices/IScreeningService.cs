using Cinema.DataAccess.Services.RepositoryServices;
using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.ScreeningServices
{
    public interface IScreeningService : IRepository<ScreeningDTO>
    {
        //public Task<List<ScreeningDTO>> GetScreeningsAsync();
        //public Task<ScreeningDTO> GetMovieScreeningAsync(int movieID);

        //public Task CreateMovieScreeningAsync(ScreeningDTO screening);
        //public Task UpdateMovieScreeningAsync(ScreeningDTO screening);
        //public Task DeleteMovieScreeningAsync(int screeningID);
    }
}
