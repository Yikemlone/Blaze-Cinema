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

        // Gets
        public async Task<List<BookingDTO>> GetBookingsAsync()
        {
            var bookings = _context.Bookings
                .Select(b => new BookingDTO()
                {
                    ID = b.ID,
                    Status = b.Status,
                })
                .ToList();

            return bookings;
        }

        public async Task<List<BookingDTO>> GetCustomerBookingsAsync(int customerID)
        {
            var bookings = _context.Bookings
                .Where(b => b.ID == customerID)
                .Select(b => new BookingDTO()
                {
                    ID = b.ID,
                    Status = b.Status,
                })
                .ToList();

            return bookings;
        }


        // Add, Update and Delete
        public async Task CreateBookingAsync(BookingDTO booking)
        {
            var newBooking = new Booking()
            {
                Status = booking.Status,
            };

            if (booking.Customer != null) 
            {
                newBooking.CustomerID = booking.Customer.ID;
            }

            await _context.AddAsync(newBooking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingAsync(BookingDTO booking)
        {
            var oldBooking = _context.Bookings
                .Where(b => b.ID == booking.ID)
                .Select(b => b)
                .FirstOrDefault();

            if (oldBooking == null) return;
            oldBooking.Status = booking.Status;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int bookingID)
        {
            var bookingToRemove = _context.Bookings
                .Where(b => b.ID == bookingID)
                .Select(b => b);

            _context.Remove(bookingToRemove);
            await _context.SaveChangesAsync();
        }
    }
}
