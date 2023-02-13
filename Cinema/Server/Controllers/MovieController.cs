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

        // We use this to GET data from the database
        [HttpGet]
        [ResponseType(typeof(MovieDTO))]
        [Route("movies")]
        public async Task<IEnumerable<MovieDTO>> GetMovies()
        {
            return await _movieService.GetMovies();
        }

        // We will use a POST to UPDATE, ADD and DELETE movies
        [HttpPost]
        // We should ensure the person using this is an Admin
        [Route("update")]
        public async Task UpdateMovie([FromBody] MovieDTO movie)
        {
            await _movieService.UpdateMovie(movie);
        }

        // An example of getting a single movie from a GET request
        // We will use this for the single movie details page
        [HttpGet]
        [Route("movies/{movieID}")]
        public async Task<MovieDTO> GetMovie(int movieID)
        {
            return await _movieService.GetMovie(movieID);
        }
    }
}
