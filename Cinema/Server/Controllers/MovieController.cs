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
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // Use this to GET data from the database
        [HttpGet]
        [ResponseType(typeof(List<MovieDTO>))]
        [Route("movies")]
        public async Task<List<MovieDTO>> GetMovies()
        {

            return await _movieService.GetMoviesAsync();
        }

        // Use a POST to UPDATE, ADD and DELETE movies
        [HttpPost]
        // Ensure the person using this is an Admin
        [Route("update")]
        public async Task UpdateMovie([FromBody] MovieDTO movie)
        {
            await _movieService.UpdateMovieAsync(movie);
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
    }
}
