using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.BookingService
{
    public interface IBookingService
    {
        public Task<BookingDTO> GetBookingAsync(int ID);
    }
}
