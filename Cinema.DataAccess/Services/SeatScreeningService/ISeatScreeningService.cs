using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.SeatScreeningService
{
    public interface ISeatScreeningService
    {
        public Task<List<SeatScreeningDTO>> GetSeatsScreeningAsync(int screeningID); // Getting all seats for a screening
        public Task<SeatScreeningDTO> GetSeatScreeningAsync(int seatScreeningID); // Get the seat for that screening 
        public Task UpdateSeatScreeningAsync(SeatScreeningDTO seatScreening); // Update the seat screening
        public Task UpdateSeatsScreeningAsync(List<SeatScreeningDTO> seatScreening); // Update the seat screening
    }
}
