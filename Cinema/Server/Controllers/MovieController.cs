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
        //[Route("movie")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //}


        // We will use POST to UPDATE, ADD and DELETE movies
        //[HttpPost]
        //public async Task UpdateBills([FromBody] BillDto updatedBills)
        //{
        //    await _billsService.UpdateBills(updatedBills);
        //}
    }
}
