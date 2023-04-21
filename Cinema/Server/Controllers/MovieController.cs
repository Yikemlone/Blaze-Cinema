using Cinema.DataAccess.Services.UnitOfWorkServices;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
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
            return await _unitOfWork.MovieService.GetAllAsync();
        }

        [HttpGet]
        [Route("movies/{movieID}")]
        public async Task<MovieDTO> GetMovie(int movieID)
        {
            return await _unitOfWork.MovieService.GetAsync(movieID);
        }

        // Screenings
        [HttpGet]
        [Route("screenings")]
        public async Task<List<ScreeningDTO>> GetScreenings()
        {
            return await _unitOfWork.ScreeningService.GetAllAsync();
        }

        [HttpGet]
        [Route("screenings/{movieID}")]
        public async Task<ScreeningDTO> GetMovieScreening(int movieID)
        {
            return await _unitOfWork.ScreeningService.GetAsync(movieID);
        }
            
        // Seat Screenings
        [HttpGet]
        [Route("seats/{screeningID}")]
        public async Task<List<SeatScreeningDTO>> GetSeatScreenings(int screeningID)
        {
            // This returns all the seats for a screening
            return await _unitOfWork.SeatScreeningService.GetAllAsync(screeningID); 
        }

        [HttpGet]
        [Route("seat/{seatScreeningID}")]
        public async Task<SeatScreeningDTO> GetSeatScreening(int seatScreeningID)
        {
            // This returns the seat for a screening
            return await _unitOfWork.SeatScreeningService.GetAsync(seatScreeningID);
        }

        [HttpPost]
        [Route("seat")]
        public async Task UpdateSeatScreening([FromBody] SeatScreeningDTO seatScreening)
        {
            // Updates the seats state
            await _unitOfWork.SeatScreeningService.UpdateAsync(seatScreening);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Route("seats")]
        public async Task UpdateSeatsScreening([FromBody] List<SeatScreeningDTO> seatsScreening)
        {
            // Updates the seats state
            await _unitOfWork.SeatScreeningService.UpdateAllAsync(seatsScreening);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Authorize(Policy=("IsAdmin"))]
        [Route("create")]
        public async Task CreateMovie([FromBody] MovieDTO movie)
        {
            await _unitOfWork.MovieService.AddAsync(movie);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Authorize(Policy = ("IsAdmin"))]
        [Route("update")]
        public async Task UpdateMovie([FromBody] MovieDTO movie)
        {
            await _unitOfWork.MovieService.UpdateAsync(movie);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Authorize(Policy = ("IsAdmin"))]
        [Route("delete")]
        public async Task DeleteMovie([FromBody] MovieDTO movie)
        {
            await _unitOfWork.MovieService.DeleteAsync(movie);
            await _unitOfWork.SaveAsync();
        }
    }
}
