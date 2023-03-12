using Cinema.Shared.DTO;

namespace Cinema.Server.Services.Customers
{
    public interface IBookingService
    {
        public Task<BookingDTO> GetBookingAsync(int bookingID);
        public Task<BookingDTO> GetBookingsAsync(int customerID);

        public Task CreateBookingAsync(BookingDTO bookingDTO);
        public Task UpdateBookingAsync(BookingDTO bookingDTO);
        public Task DeleteBookingAsync(int bookingID);
    }
}
