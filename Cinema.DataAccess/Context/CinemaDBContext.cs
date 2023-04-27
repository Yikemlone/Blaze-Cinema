using Cinema.Models.Models;
using Cinema.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading;

namespace Cinema.DataAccess.Context
{
    public class CinemaDBContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Seat>()
                .HasOne(e => e.Room)
                .WithMany(e => e.Seats)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}