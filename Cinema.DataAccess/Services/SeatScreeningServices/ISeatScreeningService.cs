using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.SeatScreeningServices
{
    public interface ISeatScreeningService
    {
        public Task<List<SeatScreeningDTO>> GetAllAsync(int screeningID); // Getting all seats for a screening
        public Task<SeatScreeningDTO> GetAsync(int seatScreeningID); // Get the seat for that screening 
        public Task UpdateAsync(SeatScreeningDTO seatScreening); // Update the seat screening
        public Task UpdateAllAsync(List<SeatScreeningDTO> seatScreening); // Update the seat screening
    }
}
