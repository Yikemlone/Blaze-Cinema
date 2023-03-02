using Cinema.Shared.DTO;

namespace Cinema.Server.Services.Customers
{
    public interface IBookingService
    {
        public Task<BookingDTO> GetBookingAsync(int ID);
    }
}
