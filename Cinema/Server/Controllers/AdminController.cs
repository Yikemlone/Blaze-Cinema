using Cinema.DataAccess.Services.AdminService;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Controllers
{
    [Authorize(Policy ="IsAdmin")]
    [ApiController]
    [Route("/api/[controller]")]
    public class AdminController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [Route("create")]
        public async Task CreateMovie([FromBody] MovieDTO movie)
        {
            await _adminService.CreateMovieAsync(movie);
        }

        [HttpPost]
        [Route("update")]
        public async Task UpdateMovie([FromBody] MovieDTO movie)
        {
            await _adminService.UpdateMovieAsync(movie);
        }

        [HttpPost]
        [Route("delete/{movieID}")]
        public async Task DeleteMovie(int movieID)
        {
            await _adminService.DeleteMovieAsync(movieID);
        }
    }
}
