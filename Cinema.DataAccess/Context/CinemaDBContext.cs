using Cinema.Models.Models;
using Cinema.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Security.Claims;
using System.Threading;

namespace Cinema.DataAccess.Context
{
    public class CinemaDBContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private bool _isUserCreated = false;

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatScreening> SeatScreenings { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<TicketTypeBooking> TicketTypesBookings { get; set; }

        public CinemaDBContext(DbContextOptions<CinemaDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}