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

        //[HttpGet]
        //[ResponseType(typeof(MovieDTO))]
        //[Route("movies")]
        //public async Task<IEnumerable<<MovieDTO>> GetMovies()
        //{
        //}


        // We will use POST to UPDATE, ADD and DELETE movies

        //[HttpPost]
        //public async Task UpdateBills([FromBody] BillDto updatedBills)
        //{
        //    await _movieService.UpdateBills(updatedBills);
        //}


        // An example of getting a single movie from a GET request

        //[HttpGet]
        //[Route("movies/{nameOfMovie}")]
        //public async Task<MovieDTO> GetMovie(int nameOfMovie)
        //{
        //    var personBills = await _movieService.GetMovie(nameOfMovie);
        //    MovieDTO retVal = personBills;
        //    return retVal;
        //}
    }
}
