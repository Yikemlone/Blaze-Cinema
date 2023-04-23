using Cinema.DataAccess.Context;
using Cinema.DataAccess.Services.RepositoryServices;
using Cinema.Models.Models;
using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly CinemaDBContext _context;

        public MovieService(CinemaDBContext context) 
        {
            _context = context;
        }

        // Movies
        public async Task<MovieDTO> GetAsync(int movieID)
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
                                MovieID = s.MovieID,
                                RoomID = s.RoomID
                            })
                            .OrderBy(s => s.DateTime)
                            .ToList()
                    ),
				 })
                 .SingleOrDefault();
            
            return movie;
        }

        public async Task<List<MovieDTO>> GetAllAsync()
        {
            var movies = _context.Movies
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
                                MovieID = m.ID,
                                RoomID = s.RoomID
                            })
                            .OrderBy(s => s.DateTime)
                            .ToList()
                    ),
                    
				})
                .ToList();

            return movies;
        }

        public async Task AddAsync(MovieDTO movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                AgeRating = movie.AgeRating,
                Duration = movie.Duration,
                Trailer = movie.Trailer,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate
            };

            await _context.AddAsync(newMovie);
        }

        public async Task UpdateAsync(MovieDTO movie)
        {
            var oldMovie = _context.Movies
                 .Select(m => m)
                 .Where(m => m.ID == movie.ID)
                 .SingleOrDefault();

            if (oldMovie == null) return;

            oldMovie.Name = movie.Name;
            oldMovie.AgeRating = movie.AgeRating;
            oldMovie.Duration = movie.Duration;
            oldMovie.Description = movie.Description;
            oldMovie.ReleaseDate = movie.ReleaseDate;
            oldMovie.Trailer = movie.Trailer;
        }

        public async Task DeleteAsync(MovieDTO movie)
        {
            var movieToDelete = _context.Movies
               .FirstOrDefault(x => x.ID == movie.ID);

            if (movieToDelete == null) return;

            _context.Movies.Remove(movieToDelete);
        }
    }
}
