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

        public Task CreateBookingAsync(BookingDTO bookingDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBookingAsync(int bookingID)
        {
            {
                var booking = _context.Bookings
                    .Where(m => m.ID == bookingID)
                    .Select(s => s)
                    .FirstOrDefault();

                if (booking == null) return;

                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<BookingDTO> GetBookingAsync(int bookingID)
        {
            var booking = _context.Bookings
                 .Where(m => m.ID == bookingID)
                 .Select(m => new BookingDTO()
                 {
                     ID = m.ID,
                     Status = m.Status,
                     CustomerID = m.CustomerID,
                 })
                 .SingleOrDefault();
            return booking;
        }

        public async Task<List<BookingDTO>> GetBookingsAsync(int customerID)
        {
            List<BookingDTO> bookings = _context.Bookings
              .Select(m => new BookingDTO()
              {
                  ID = m.ID,
                  Status = m.Status,
                  CustomerID = m.CustomerID,
              }).ToList();

            return bookings;
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
