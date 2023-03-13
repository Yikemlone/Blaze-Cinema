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
                    .ToList();  
            }

            return movies;
        }

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
    }
}
