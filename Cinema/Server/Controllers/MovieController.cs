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

        [HttpGet]
        [Route("seats")]
        public async Task<ScreeningDTO> GetSeatScreenings(int screeningID)
        {
            return await _movieService.GetMovieScreeningAsync(screeningID);
        }

        [HttpPost]
        [Route("screenings/{movieID}")]
        public async Task<ScreeningDTO> UpdateSeatScreening([FromBody] SeatScreeningDTO seatScreening)
        {
            return await _movieService.UpdateSeatScreening(seatScreening);
        }
    }
}
