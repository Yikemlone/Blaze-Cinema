using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.Shared.DTO;
using Microsoft.EntityFrameworkCore;

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
                    BookingRef = b.BookingRef,
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
                    BookingRef = b.BookingRef,
                    Status = b.Status,
                })
                .ToList();

            return bookings;
        }


        // Add, Update and Delete
        public async Task CreateBookingAsync(BookingDTO booking, List<TicketTypeBookingDTO> ticketTypeBookings)
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

            foreach (var seatScreening in booking.SeatScreenings)
            {
                var oldSeatScreening = _context.SeatScreenings
                    .Where(sc => sc.ID == seatScreening.ID)
                    .Select(s => s)
                    .SingleOrDefault();

                if (oldSeatScreening == null) return;
                oldSeatScreening.BookingID = newBooking.ID;
                oldSeatScreening.Booked = seatScreening.Booked;
            }

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
            await _context.SaveChangesAsync();

        }

        public async Task UpdateBookingAsync(BookingDTO booking, List<TicketTypeBookingDTO> ticketTypeBookings)
        {
            var oldBooking = _context.Bookings
                .Where(b => b.ID == booking.ID)
                .Select(b => b)
                .FirstOrDefault();

            if (oldBooking == null) return;
            oldBooking.Status = booking.Status;

            if (oldBooking.Status.Equals("Cancelled")) 
            {
                var seat = _context.SeatScreenings
                    .Select(s => s)
                    .Where(s => s.BookingID == oldBooking.ID)
                    .FirstOrDefault();

                if (seat != null)
                {
                    seat.Booked = false;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int bookingID)
        {
            var bookingToRemove = _context.Bookings
                .Where(b => b.ID == bookingID)
                .Select(b => b);

            var seat = _context.SeatScreenings
                .Where(s => s.BookingID == bookingID)
                .Select(s => s)
                .FirstOrDefault();

            if (seat != null) 
            { 
                seat.Booked = false;
            }

            _context.Remove(bookingToRemove);
            await _context.SaveChangesAsync();
        }
    }
}
