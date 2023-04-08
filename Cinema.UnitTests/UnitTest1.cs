using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Cinema.DataAccess.Context;
using Cinema.DataAccess.Services.BookingService;
using Cinema.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.UnitTests {
    public class UnitTest1
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
                var booking1 = new Booking() { ID = 1, BookingRef = "Ref1", Status = "Booked" };
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
                Assert.Contains(bookings, b => b.ID == 1 && b.BookingRef == "Ref1" && b.Status == "Booked");
                Assert.Contains(bookings, b => b.ID == 2 && b.BookingRef == "Ref2" && b.Status == "Cancelled");
            }
        }

        [Fact]
        public async Task GetCustomerBookingsAsync_ShouldReturnBookingsForCustomer()
        {
            // Arrange
            using (var context = new CinemaDBContext(_options))
            {
                var customer = new Customer() { ID = 1, Email = "test@email.com", FirstName = "Mikey", LastName = "Creamer" };
                var booking1 = new Booking() { ID = 1, BookingRef = "Ref1", Status = "Booked", Customer = customer };
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
                Assert.Single(bookings);
                Assert.Contains(bookings, b => b.ID == 1 && b.BookingRef == "Ref1" && b.Status == "Booked");
            }
        }
    }
}