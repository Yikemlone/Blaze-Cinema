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
        
        public async Task<List<BookingDTO>> GetAsync()
        {
            var bookings = await _context.Bookings
                .Select(b => new BookingDTO()
                {
                    ID = b.ID,
                    BookingRef = b.BookingRef,
                    Status = b.Status,
                })
                .ToListAsync();

            return bookings;
        }

        public async Task<List<BookingDTO>> GetAllAsync(int customerID)
        {
            var bookings = await _context.Bookings
                .Where(b => b.CustomerID == customerID)
                .Select(b => new BookingDTO()
                {
                    ID = b.ID,
                    BookingRef = b.BookingRef,
                    Status = b.Status,
                })
                .ToListAsync();

            return bookings;
        }

        public async Task AddAsync(BookingDTO booking, List<TicketTypeBookingDTO> ticketTypeBookings)
        {
            var newBooking = new Booking()
            {
                BookingRef = booking.BookingRef,
                Status = booking.Status
            };

            if (booking.Customer != null)
            {
                newBooking.CustomerID = booking.Customer.ID;
            }

            await _context.AddAsync(newBooking);
            await _context.SaveChangesAsync();

            // Update Seats with booking ID
            foreach (var seatScreening in booking.SeatScreenings)
            {
                var oldSeatScreening = await _context.SeatScreenings
                    .Where(sc => sc.ID == seatScreening.ID)
                    .Select(s => s)
                    .FirstOrDefaultAsync();

                if (oldSeatScreening == null) continue;
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

            await _context.AddRangeAsync(tickets);
        }

        public async Task UpdateAsync(BookingDTO booking, List<TicketTypeBookingDTO> ticketTypeBookings)
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

        public async Task DeleteAsync(int bookingID)
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


            // THIS NEEDS TO BE TESTED
            _context.Remove(bookingToRemove);
        }
    }
}
