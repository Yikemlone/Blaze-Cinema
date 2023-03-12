using Cinema.Server.Models;
using Cinema.Shared.DTO;

namespace Cinema.Server.Services.Customers
{
    public class BookingService : IBookingService
    {
        private readonly CinemaDBContext _context;
        public BookingService(CinemaDBContext context)
        {
            _context = context;
        }

        public Task CreateBookingAsync(BookingDTO bookingDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookingAsync(int bookingID)
        {
            throw new NotImplementedException();
        }

        public Task<BookingDTO> GetBookingAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<BookingDTO> GetBookingsAsync(int customerID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookingAsync(BookingDTO bookingDTO)
        {
            throw new NotImplementedException();
        }

        //public Task<BookingDTO> GetBookingAsync(int bookingID)
        //{
        //    var booking = _context.Bookings
        //        .Where(b => b.ID == bookingID)
        //        .Select(b => new Booking()
        //        {
        //            ID = b.ID,
        //            Status = b.Status,
        //        });
        //    var seats = _context.SeatScreenings
        //        .Where(s => s.BookingID == bookingID)
        //}
    }
}
