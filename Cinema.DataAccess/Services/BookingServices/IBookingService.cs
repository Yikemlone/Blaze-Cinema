using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.BookingServices
{
    public interface IBookingService
    {
        public Task<List<BookingDTO>> GetBookingsAsync();
        public Task<List<BookingDTO>> GetCustomerBookingsAsync(int customerID);

        public Task CreateBookingAsync(BookingDTO bookingDTO, List<TicketTypeBookingDTO> ticketTypeBooking);
        public Task UpdateBookingAsync(BookingDTO bookingDTO, List<TicketTypeBookingDTO> ticketTypeBooking);
        public Task DeleteBookingAsync(int bookingID);
    }
}
