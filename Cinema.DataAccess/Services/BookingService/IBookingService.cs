using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.BookingService
{
    public interface IBookingService
    {
        public Task<List<BookingDTO>> GetBookingsAsync();
        public Task<List<BookingDTO>> GetCustomerBookingsAsync(int customerID);

        public Task CreateBookingAsync(BookingDTO bookingDTO);
        public Task UpdateBookingAsync(BookingDTO bookingDTO);
        public Task DeleteBookingAsync(int bookingID);
    }
}
