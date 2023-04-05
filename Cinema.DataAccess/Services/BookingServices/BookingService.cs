using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services.BookingServices
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
                    BookingRef = b.BookingRef,
                    Status = b.Status,
                })
                .ToList();

            return bookings;
        }

        public async Task<List<BookingDTO>> GetCustomerBookingsAsync(int customerID)
        {
            var bookings = _context.Bookings
                .Where(b => b.CustomerID == customerID)
                .Select(b => new BookingDTO()
                {
                    ID = b.ID,
                    BookingRef = b.BookingRef,
                    Status = b.Status,
                })
                .ToList();

            return bookings;
        }


        // Add, Update and Delete
        public async Task CreateBookingAsync(BookingDTO booking, List<TicketTypeBookingDTO> ticketTypeBookings)
        {
            // Create Booking
            var newBooking = new Booking()
            {
                ID = new Guid(),
                BookingRef = booking.BookingRef,
                Status = booking.Status
            };

            if (booking.Customer != null)
            {
                newBooking.CustomerID = booking.Customer.ID;
            }

            // Update Seats with booking ID
            foreach (var seatScreening in booking.SeatScreenings)
            {
                var oldSeatScreening = await _context.SeatScreenings
                    .Where(sc => sc.ID == seatScreening.ID)
                    .Select(s => s)
                    .FirstOrDefaultAsync();

                if (oldSeatScreening == null) return;
                oldSeatScreening.BookingID = newBooking.ID;
                oldSeatScreening.Booked = seatScreening.Booked;
            }

            // Adding new ticket types with booking ID
            var tickets = new List<TicketTypeBooking>();

            foreach (var ticket in ticketTypeBookings)
            {
                tickets.Add(new TicketTypeBooking()
                {
                    BookingID = newBooking.ID,
                    TicketTypeID = ticket.TicketTypeID,
                });
            }

            await _context.AddAsync(newBooking);
            await _context.AddRangeAsync(tickets);
        }

        public async Task UpdateBookingAsync(BookingDTO booking, List<TicketTypeBookingDTO> ticketTypeBookings)
        {
            var oldBooking = await _context.Bookings
                .Where(b => b.ID == booking.ID)
                .Select(b => b)
                .FirstOrDefaultAsync();

            if (oldBooking == null) return;
            oldBooking.Status = booking.Status;

            if (oldBooking.Status.Equals("Cancelled")) 
            {
                var seat = await _context.SeatScreenings
                    .Select(s => s)
                    .Where(s => s.BookingID == oldBooking.ID)
                    .FirstOrDefaultAsync();

                if (seat != null)
                {
                    seat.Booked = false;
                }
            }
        }

        public async Task DeleteBookingAsync(Guid bookingID)
        {
            var bookingToRemove = await _context.Bookings
                .Where(b => b.ID == bookingID)
                .Select(b => b)
                .FirstOrDefaultAsync();

            var seats = await _context.SeatScreenings
                .Where(s => s.BookingID == bookingID)
                .Select(s => s)
                .ToListAsync();

            foreach (var seat in seats)
            {
                seat.Booked = false; // Changes seat to no longer be booked
                seat.BookingID = null; // Removes the booking ID
            }

            _context.Remove(bookingToRemove);
        }
    }
}
