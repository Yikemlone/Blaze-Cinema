using Cinema.DataAccess.Services.UnitOfWorkServices;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MovieController
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieController(IUnitOfWork movieService)
        {
            _unitOfWork = movieService;
        }

        // Movies
        [HttpGet]
        [Route("movies")]
        public async Task<List<MovieDTO>> GetMovies()
        {
            return await _unitOfWork.MovieService.GetMoviesAsync();
        }

        [HttpGet]
        [Route("movies/{movieID}")]
        public async Task<MovieDTO> GetMovie(int movieID)
        {
            return await _unitOfWork.MovieService.GetMovieAsync(movieID);
        }


        // Screenings
        [HttpGet]
        [Route("screenings")]
        public async Task<List<ScreeningDTO>> GetScreenings()
        {
            return await _unitOfWork.MovieService.GetScreeningsAsync();
        }

        [HttpGet]
        [Route("screenings/{movieID}")]
        public async Task<ScreeningDTO> GetMovieScreening(int movieID)
        {
            return await _unitOfWork.MovieService.GetMovieScreeningAsync(movieID);
        }

            
        // Seat Screenings
        [HttpGet]
        [Route("seats/{screeningID}")]
        public async Task<List<SeatScreeningDTO>> GetSeatScreenings(int screeningID)
        {
            // This returns all the seats for a screening
            return await _unitOfWork.MovieService.GetSeatsScreeningAsync(screeningID);
        }

        [HttpGet]
        [Route("seat/{seatScreeningID}")]
        public async Task<SeatScreeningDTO> GetSeatScreening(int seatScreeningID)
        {
            // This returns the seat for a screening
            return await _unitOfWork.MovieService.GetSeatScreeningAsync(seatScreeningID);
        }

        [HttpPost]
        [Route("seat")]
        public async Task UpdateSeatScreening([FromBody] SeatScreeningDTO seatScreening)
        {
            // Updates the seats state
            await _unitOfWork.MovieService.UpdateSeatScreeningAsync(seatScreening);
        }

        [HttpPost]
        [Route("seats")]
        public async Task UpdateSeatsScreening([FromBody] List<SeatScreeningDTO> seatsScreening)
        {
            // Updates the seats state
            await _unitOfWork.MovieService.UpdateSeatsScreeningAsync(seatsScreening);
        }
    }
}
