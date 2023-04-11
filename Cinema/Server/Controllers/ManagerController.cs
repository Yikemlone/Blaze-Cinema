using Cinema.Server.Services.Employees;
using Cinema.Server.Services.Movies;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ManagerController
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet]
        [Route("employees")]
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            return await _managerService.GetEmployeesAsync();
        }

        //get employee
        [HttpGet]
        [Route("employees/{employeeID}")]
        public async Task<EmployeeDTO> GetEmployee(int employeeID)
        {
            return await _managerService.GetEmployeeAsync(employeeID);
        }

        // Create moviescreening
        [HttpPost]
        [Route("create")]
        public async Task CreateMovieScreening([FromBody] ScreeningDTO screening)
        {
            await _managerService.CreateMovieScreeningAsync(screening);
        }

        // update moviescreening
        [HttpPost]
        [Route("update")]
        public async Task UpdateScreening([FromBody] ScreeningDTO screening)
        {
            await _managerService.UpdateMovieScreeningAsync(screening);
        }

        // delete moviescreening
        [HttpPost]
        [Route("delete/{screeningID}")]
        public async Task DeleteMovieScreening(int screeningID)
        {
            await _managerService.DeleteMovieScreeningAsync(screeningID);
        }
    }
}
