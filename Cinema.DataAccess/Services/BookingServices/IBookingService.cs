using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.BookingServices
{
    public interface IBookingService
    {
        public Task<List<BookingDTO>> GetAllAsync();
        public Task<List<BookingDTO>> GetAsync(int customerID);
        public Task<List<TicketTypeDTO>> GetTicketTypesAsync();


        public Task AddAsync(BookingDTO bookingDTO, List<TicketTypeBookingDTO> ticketTypeBooking);
        public Task UpdateAsync(BookingDTO bookingDTO, List<TicketTypeBookingDTO> ticketTypeBooking);
        public Task DeleteAsync(int bookingID);
    }
}
