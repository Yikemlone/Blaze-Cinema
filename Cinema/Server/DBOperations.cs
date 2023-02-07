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

        public void AddMovies() 
        {
        }

        public void AddRooms() 
        {
        }

        public void AddSeats() 
        {
        }

        public void AddEmployees() 
        {
        }
    }
}
