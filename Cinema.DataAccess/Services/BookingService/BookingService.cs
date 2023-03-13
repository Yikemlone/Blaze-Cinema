using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly CinemaDBContext _context;
        public BookingService(CinemaDBContext context)
        {
            _context = context;
        }

        public Task<BookingDTO> GetBookingAsync(int ID)
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
