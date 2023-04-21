using Cinema.DataAccess.Services.RepositoryServices;
using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.BookingServices
{
    public interface IBookingService
    {
        public Task<List<BookingDTO>> GetAsync();
        public Task<List<BookingDTO>> GetAllAsync(int customerID);

        public Task AddAsync(BookingDTO bookingDTO, List<TicketTypeBookingDTO> ticketTypeBooking);
        public Task UpdateAsync(BookingDTO bookingDTO, List<TicketTypeBookingDTO> ticketTypeBooking);
        public Task DeleteAsync(int bookingID);
    }
}
