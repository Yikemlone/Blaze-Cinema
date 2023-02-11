using Cinema.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Cinema.Server
{
    public class CinemaDBContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public CinemaDBContext(DbContextOptions options) : base(options)
        {
        }

    }
}
