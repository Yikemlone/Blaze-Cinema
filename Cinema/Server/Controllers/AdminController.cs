using Cinema.DataAccess.Services.UnitOfWorkServices;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AdminController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("create")]
        public async Task CreateMovie([FromBody] MovieDTO movie)
        {
            await _unitOfWork.AdminService.CreateMovieAsync(movie);
        }

        [HttpPost]
        [Route("update")]
        public async Task UpdateMovie([FromBody] MovieDTO movie)
        {
            await _unitOfWork.AdminService.UpdateMovieAsync(movie);
        }

        [HttpPost]
        [Route("delete/{movieID}")]
        public async Task DeleteMovie(int movieID)
        {
            await _unitOfWork.AdminService.DeleteMovieAsync(movieID);
        }
    }
}
