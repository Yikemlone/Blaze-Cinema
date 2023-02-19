using Cinema.Server.Services.Movies;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

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
        [ResponseType(typeof(List<MovieDTO>))]
        [Route("movies")]
        public async Task<List<MovieDTO>> GetMovies()
        {

            return await _movieService.GetMoviesAsync();
        }

        // An example of getting a single movie from a GET request
        // Use this for the single movie details page
        [HttpGet]
        [ResponseType(typeof(MovieDTO))]
        [Route("movies/{movieID}")]
        public async Task<MovieDTO> GetMovie(int movieID)
        {
            return await _movieService.GetMovieAsync(movieID);
        }

        [HttpGet]
        [ResponseType(typeof(List<ScreeningDTO>))]
        [Route("screenings")]
        public async Task<List<ScreeningDTO>> GetScreenings()
        {

            return await _movieService.GetScreeningsAsync();
        }

        //[HttpGet]
        //[ResponseType(typeof(ScreeningDTO))]
        //[Route("screenings/{movieID}")]
        //public async Task<ScreeningDTO> GetMovieScreening(int movieID)
        //{
        //    return await _movieService.GetMovieScreeningAsync(movieID);
        //}
    }
}
