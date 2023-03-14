using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly CinemaDBContext _context;

        public MovieService(CinemaDBContext context) 
        {
            _context = context;
        }

        // Movies
        public async Task<MovieDTO> GetMovieAsync(int movieID)
        {
            var movie = _context.Movies
                 .Where(m => m.ID == movieID)
                 .Select(m => new MovieDTO()
                 {
                    ID = m.ID,
                    Name = m.Name,
                    AgeRating = m.AgeRating,
                    Duration = m.Duration,
                    Trailer = m.Trailer,
                    Description = m.Description
                 })
                 .SingleOrDefault();

            movie.Screenings = _context.Screenings
                .Where(s => s.MovieID == movie.ID)
                .Select(s => new ScreeningDTO() 
                {
                    ID = s.ID,
                    DateTime = s.DateTime,
                    MovieID = s.ID,
                    RoomID = s.RoomID
                })
                .OrderBy(s => s.DateTime)
                .ToList();

            return movie;
        }

        public async Task<List<MovieDTO>> GetMoviesAsync()
        {
            List<MovieDTO> movies = _context.Movies
                .Select(m => new MovieDTO() 
                {
                    ID = m.ID,
                    Name = m.Name,
                    AgeRating = m.AgeRating,
                    Duration = m.Duration,
                    Trailer = m.Trailer,
                    Description = m.Description
                })
                .ToList();

            foreach (var movie in movies)
            {
                movie.Screenings = _context.Screenings
                    .Where(s => s.MovieID == movie.ID)
                    .Select(s => new ScreeningDTO()
                    {
                        ID = s.ID,
                        DateTime = s.DateTime,
                        MovieID = s.ID,
                        RoomID = s.RoomID
                    })
                    .OrderBy(s => s.DateTime)
                    .ToList();  
            }

            return movies;
        }


        // Screenings
        public async Task<List<ScreeningDTO>> GetScreeningsAsync()
        {
            List<ScreeningDTO> Screenings = _context.Screenings
                .Select(m => new ScreeningDTO()
                {
                    ID = m.ID,
                    MovieID = m.MovieID,
                    RoomID = m.RoomID,
                    DateTime = m.DateTime
                })
                .ToList();

            return Screenings;
        }

        public async Task <ScreeningDTO> GetMovieScreeningAsync(int movieID)
        {
            var Screening = _context.Screenings
                .Where(m => m.ID == movieID)
                .Select(m => new ScreeningDTO()
                {
                    ID = m.ID,
                    MovieID = m.MovieID,
                    RoomID = m.RoomID,
                    DateTime = m.DateTime

                })
                .SingleOrDefault();

            return Screening;
        }


        // SeatScreenings
        public async Task<List<SeatScreeningDTO>> GetSeatsScreeningAsync(int screeningID)
        {
            List<SeatScreeningDTO> seatScreenings = _context.SeatScreenings
                .Where(m => m.ID == screeningID)
                .Select(m => new SeatScreeningDTO()
                {
                    ID = m.ID,
                    Booked = m.Booked
                })
                .ToList();

            // Need the booking 

            //foreach (var item in seatScreenings)
            //{
            //    var booking = _context.Bookings
            //        .Where(b => b.ID == item.)
            //}

            // Need the seat

            // Need Screening

           return seatScreenings;
        }

        public async Task<SeatScreeningDTO> GetSeatScreeningAsync(int seatScreeningID)
        {
            var SeatScreening = _context.SeatScreenings
                .Where(m => m.ID == seatScreeningID)
                .Select(m => new SeatScreeningDTO()
                {
                    ID = m.ID,
                    Booked=m.Booked
                })
                .SingleOrDefault();

            return SeatScreening;
        }

        public async Task UpdateSeatScreeningAsync(SeatScreeningDTO seatScreening)
        {
            var oldSeatScreening = _context.SeatScreenings
                .Select(m => m)
                .Where(m => m.ID == seatScreening.ID)
                .SingleOrDefault();

            if (oldSeatScreening == null) return;
            oldSeatScreening.Booked = seatScreening.Booked;

            await _context.SaveChangesAsync();
        }

    }
}
