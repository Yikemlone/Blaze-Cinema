using Cinema.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Cinema.Server
{
    public class CinemaDBContext : DbContext
    {
        public CinemaDBContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Booking> Bookings { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Schedule> Schedules { get; set; }
        DbSet<Seat> Seats { get; set; }
        DbSet<MovieTransaction> Transactions { get; set; }

    }
}
