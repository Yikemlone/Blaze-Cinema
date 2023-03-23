using Cinema.DataAccess.Context;
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
                    Description = m.Description,
                    ReleaseDate = (DateTime)m.ReleaseDate,
                    Screenings = (_context.Screenings
                            .Where(s => s.MovieID == m.ID)
                            .Select(s => new ScreeningDTO()
                            {
                                ID = s.ID,
                                DateTime = s.DateTime,
                                MovieID = s.ID,
                                RoomID = s.RoomID
                            })
                            .OrderBy(s => s.DateTime)
                            .ToList()
                    ),
				 })
                 .SingleOrDefault();
            
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
                    Description = m.Description,
                    ReleaseDate = (DateTime)m.ReleaseDate,
                    Screenings = (_context.Screenings
                            .Where(s => s.MovieID == m.ID)
                            .Select(s => new ScreeningDTO()
                            {
                                ID = s.ID,
                                DateTime = s.DateTime,
                                MovieID = s.ID,
                                RoomID = s.RoomID
                            })
                            .OrderBy(s => s.DateTime)
                            .ToList()
                    ),
                    
				})
                .ToList();

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
                .Where(sc => sc.ScreeningID == screeningID)
                .Select(sc => new SeatScreeningDTO()
                {
                    ID = sc.ID,
                    Booked = sc.Booked,
                    Seat = (_context.Seats
                        .Where(s => s.ID == sc.SeatID)
                        .Select(s => new SeatDTO 
                        {
                            ID = s.ID,
                            SeatNumber = s.SeatNumber,
                            RoomID = s.RoomID,
                            DisabiltySeat = s.DisabiltySeat,
                        })
                        .FirstOrDefault()
                    ),
                    BookingID = sc.BookingID,
                    ScreeningID = sc.ScreeningID
                })
                .ToList();

           return seatScreenings;
        }

        public async Task<SeatScreeningDTO> GetSeatScreeningAsync(int seatScreeningID)
        {
            var SeatScreening = _context.SeatScreenings
                .Where(sc => sc.ID == seatScreeningID)
                .Select(sc => new SeatScreeningDTO()
                {
                    ID = sc.ID,
                    Booked = sc.Booked,
                    Seat = (_context.Seats
                        .Where(s => s.ID == sc.SeatID)
                        .Select(s => new SeatDTO
                        {
                            ID = s.ID,
                            SeatNumber = s.SeatNumber,
                            RoomID = s.RoomID,
                            DisabiltySeat = s.DisabiltySeat,
                        })
                        .FirstOrDefault()
                    ),
                    BookingID = sc.BookingID,
                    ScreeningID = sc.ScreeningID
                })
                .SingleOrDefault();

            return SeatScreening;
        }

        public async Task UpdateSeatScreeningAsync(SeatScreeningDTO seatScreening)
        {
            var oldSeatScreening = _context.SeatScreenings
                .Where(sc => sc.ID == seatScreening.ID)
                .Select(s => s)
                .SingleOrDefault();

            if (oldSeatScreening == null) return;
            oldSeatScreening.Booked = seatScreening.Booked;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateSeatsScreeningAsync(List<SeatScreeningDTO> seatsScreening)
        {
            foreach (var seatScreening in seatsScreening)
            {
                var oldSeatScreening = _context.SeatScreenings
                    .Where(sc => sc.ID == seatScreening.ID)
                    .Select(s => s)
                    .SingleOrDefault();

                if (oldSeatScreening == null) return;
                oldSeatScreening.Booked = seatScreening.Booked;
            }

            await _context.SaveChangesAsync();
        }

    }
}
