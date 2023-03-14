using Cinema.DataAccess.Services.MovieService;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MovieController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // Movies
        [HttpGet]
        [Route("movies")]
        public async Task<List<MovieDTO>> GetMovies()
        {
            return await _movieService.GetMoviesAsync();
        }

        [HttpGet]
        [Route("movies/{movieID}")]
        public async Task<MovieDTO> GetMovie(int movieID)
        {
            return await _movieService.GetMovieAsync(movieID);
        }


        // Screenings
        [HttpGet]
        [Route("screenings")]
        public async Task<List<ScreeningDTO>> GetScreenings()
        {
            return await _movieService.GetScreeningsAsync();
        }

        [HttpGet]
        [Route("screenings/{movieID}")]
        public async Task<ScreeningDTO> GetMovieScreening(int movieID)
        {
            return await _movieService.GetMovieScreeningAsync(movieID);
        }

            
        // Seat Screenings
        [HttpGet]
        [Route("seatscreenings/{screeningID}")]
        public async Task<List<SeatScreeningDTO>> GetSeatScreenings(int screeningID)
        {
            // This returns all the seats for a screening
            return await _movieService.GetSeatsScreeningAsync(screeningID);
       }

        [HttpGet]
        [Route("seat/{seatScreeningID}")]
        public async Task<SeatScreeningDTO> GetSeatScreening(int seatScreeningID)
        {
            // This returns the seat for a screening
            return await _movieService.GetSeatScreeningAsync(seatScreeningID);
        }

        [HttpPost]
        [Route("seatscreenings")]
        public async Task UpdateSeatScreening([FromBody] SeatScreeningDTO seatScreening)
        {
            // Updates the seats state
            await _movieService.UpdateSeatScreeningAsync(seatScreening);
        }
    }
}
