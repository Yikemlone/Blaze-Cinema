using Cinema.DataAccess.Services.MovieService;

namespace Cinema.UnitTests {
    public class BookingTests
    {
        private readonly DbContextOptions<CinemaDBContext> _options = new DbContextOptionsBuilder<CinemaDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        [Fact]
        public async Task GetBookingsAsync_ShouldReturnAllBookings()
        {
            // Arrange
            using (var context = new CinemaDBContext(_options))
            {
                var booking1 = new Booking() { ID = 1, BookingRef = "Ref1", Status = "Confirmed" };
                var booking2 = new Booking() { ID = 2, BookingRef = "Ref2", Status = "Cancelled" };
                context.AddRange(booking1, booking2);
                await context.SaveChangesAsync();
            }

            using (var context = new CinemaDBContext(_options))
            {
                var service = new BookingService(context);

                // Act
                var bookings = await service.GetBookingsAsync();

                // Assert
                Assert.Equal(2, bookings.Count);
                Assert.Contains(bookings, b => b.ID == 1 && b.BookingRef == "Ref1" && b.Status == "Confirmed");
                Assert.Contains(bookings, b => b.ID == 2 && b.BookingRef == "Ref2" && b.Status == "Cancelled");

                context.Database.EnsureDeleted(); // Reset Database
            }
        }

        [Fact]
        public async Task GetCustomerBookingsAsync_ShouldReturnBookingsForCustomer()
        {
            // Arrange
            using (var context = new CinemaDBContext(_options))
            {
                var customer = new Customer() { ID = 3, Email = "test@email.com", FirstName = "Mikey", LastName = "Creamer" };
                var booking1 = new Booking() { ID = 1, BookingRef = "Ref1", Status = "Confirmed", CustomerID = 3 };
                var booking2 = new Booking() { ID = 2, BookingRef = "Ref2", Status = "Cancelled" };
                context.AddRange(customer, booking1, booking2);
                await context.SaveChangesAsync();
            }

            using (var context = new CinemaDBContext(_options))
            {
                var service = new BookingService(context);

                // Act
                var bookings = await service.GetCustomerBookingsAsync(1);

                // Assert
                Assert.Contains(bookings, b => b.ID == 1 && b.BookingRef == "Ref1" && b.Status == "Confirmed");

                context.Database.EnsureDeleted(); // Reset Database
            }
        }

        [Fact]
        public async Task CreateCustomerBookingsAsync_ShouldCreateBooking()
        {
            //using (var context = new CinemaDBContext(_options))
            //{

            //    await context.SaveChangesAsync();
            //}


            using (var context = new CinemaDBContext(_options))
            {
                // Arrange 
                var BookingDTO = new BookingDTO { BookingRef = "RandomChars", Status = "Pending" };

                var TicketTypeBookingDTO = new List<TicketTypeBookingDTO>()
                {
                    new TicketTypeBookingDTO{ TicketTypeID = 1},
                    new TicketTypeBookingDTO{ TicketTypeID = 1},
                    new TicketTypeBookingDTO{ TicketTypeID = 2},
                    new TicketTypeBookingDTO{ TicketTypeID = 2}
                };

                var service = new BookingService(context);

                // Act
                await service.CreateBookingAsync(BookingDTO, TicketTypeBookingDTO);

                var bookings = await service.GetBookingsAsync();

                var tickets = await context.TicketTypesBookings
                    .Where(b => b.BookingID == bookings[0].ID)
                    .Select(a => a)
                    .ToListAsync();

                var seatsScreenings = await context.SeatScreenings
                    .Where(b => b.BookingID == bookings[0].ID && b.Booked == true)
                    .Select(a => a)
                    .ToListAsync();

                // Assert
                Assert.Contains(bookings, b => b.ID == 1 && b.BookingRef == "RandomChars" && b.Status == "Pending");
                Assert.True(tickets.Count == 4);
                //Assert.True(seatsScreenings.Count == 4);

                context.Database.EnsureDeleted(); // Reset Database
            }
        }

        [Fact]
        public async Task UpdateCustomerBookingsAsync_ShouldUpdateBooking()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task DeleteCustomerBookingsAsync_ShouldDeleteBooking()
        {
            throw new NotImplementedException();
        }

    }
}