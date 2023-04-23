using Cinema.DataAccess.Services.UnitOfWorkServices;
using Cinema.Models.Models;
using Cinema.Shared;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<int>> CreateMovie([FromBody] MovieDTO movie)
        {
            var movieID = await _unitOfWork.AdminService.CreateMovieAsync(movie);
            return Ok(movieID);
        }

        [HttpPost]
        [Route("update")]
        public async Task UpdateMovie([FromBody] MovieDTO movie)
        {
            await _unitOfWork.AdminService.UpdateMovieAsync(movie);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Route("delete/{movieID}")]
        public async Task DeleteMovie(int movieID)
        {
            await _unitOfWork.AdminService.DeleteMovieAsync(movieID);
            await _unitOfWork.SaveAsync();
        }
    }
}
