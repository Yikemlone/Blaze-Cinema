using Cinema.Server.Models;

namespace Cinema.Server
{
    public class DBOperations
    {
        // This will populate the database with data that won't really change
        // We can create customers and create timetables from the system, so it
        // won't be neccessary here.
        
        private readonly CinemaDBContext _context;

        public DBOperations(CinemaDBContext context) 
        {
            _context = context;
        }

        public async void RunOperations() 
        {
            await AddMovies();
            await AddRooms();
            await AddSeats();
            await AddEmployees();
            await AddBookings();
            await AddScreenings();
        }

        public async Task AddMovies()
        {
            // Check if the table is empty or not
            var movies = _context.Movies.Select(m => m);

            if (movies == null) 
            {
                return;
            }

            List<Movie> moviesToAdd = new List<Movie> 
            { 
                new Movie { ID=1, Name = "Puss in Boots: The Last Wish", AgeRating = "PG", Duration = 102, Trailer = "RqrXhwS33yc" },
                new Movie { ID=2, Name = "Avatar: The Way of Water", AgeRating = "12A", Duration = 193, Trailer = "d9MyW72ELq0"  }
            };

            await _context.Movies.AddRangeAsync(moviesToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task AddRooms() 
        {
            // Check if the table is empty or not
            var rooms = _context.Rooms.Select(r => r);

            if (rooms == null)
            {
                return;
            }

            List<Room> roomsToAdd = new List<Room>
            {
                new Room { ID=1, Decom = false, SeatQty=50 },
                new Room { ID=2, Decom = true, SeatQty=60 },
                new Room { ID=3, Decom = false, SeatQty=70 },
                new Room { Decom = false, SeatQty=20 },
            };

            await _context.Rooms.AddRangeAsync(roomsToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task AddSeats() 
        {
            // Check if the table is empty or not
            var seats = _context.Seats.Select(s => s);

            if (seats == null)
            {
                return;
            }

            List<Seat> seatsToAdd = new List<Seat>
            {
                new Seat { SeatNumber = "A10", DisabiltySeat = false, Booked = false, ScreeningID = 3 },
                new Seat { SeatNumber = "A11", DisabiltySeat = false, Booked = true, ScreeningID = 2 },
                new Seat { SeatNumber = "A12", DisabiltySeat = false, Booked = true, ScreeningID = 1 },
            };

            await _context.Seats.AddRangeAsync(seatsToAdd);
            await _context.SaveChangesAsync();

        }

        public async Task AddEmployees()
        {            
            // Check if the table is empty or not
            var employees = _context.Employees.Select(s => s);

            if (employees == null)
            {
                return;
            }

            List<Employee> employeesToAdd = new List<Employee>
            {
                new Employee { FirstName = "Shane", LastName = "McGuire"}
            };

            await _context.Employees.AddRangeAsync(employeesToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task AddBookings()
        {
            // Check if the table is empty or not
            var bookings = _context.Bookings.Select(s => s);

            if (bookings == null)
            {
                return;
            }

            List<Booking> bookingsToAdd = new List<Booking>
            {
                new Booking {Status = "Purchased", Time = new DateTime(17/02/2023), CustomerID = 1}
            };

            await _context.Bookings.AddRangeAsync(bookingsToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task AddScreenings()
        {
            // Check if the table is empty or not
            var screenings = _context.Screenings.Select(s => s);

            if (screenings == null)
            {
                return;
            }

            List<Screening> screeningsToAdd = new List<Screening>
            {
                new Screening { MovieID = 1, RoomID = 1}
            };

            await _context.Screenings.AddRangeAsync(screeningsToAdd);
            await _context.SaveChangesAsync();
        }

    }
}
