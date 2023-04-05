using Cinema.Models.Models;
using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.MovieServices
{
    public interface IMovieService
    {
        public Task<List<MovieDTO>> GetMoviesAsync();
        public Task<MovieDTO> GetMovieAsync(int movieID);

        public Task<List<ScreeningDTO>> GetScreeningsAsync();
        public Task<ScreeningDTO> GetMovieScreeningAsync(Guid movieID);

        public Task<List<SeatScreeningDTO>> GetSeatsScreeningAsync(Guid screeningID); // Getting all seats for a screening
        public Task<SeatScreeningDTO> GetSeatScreeningAsync(int seatScreeningID); // Get the seat for that screening 
        public Task UpdateSeatScreeningAsync(SeatScreeningDTO seatScreening); // Update the seat screening
        public Task UpdateSeatsScreeningAsync(List<SeatScreeningDTO> seatScreening); // Update the seat screening

    }
}
