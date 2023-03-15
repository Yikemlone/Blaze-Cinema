using Cinema.DataAccess.Services.ManagerService;
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

        // Screenings
        [HttpPost]
        [Route("create")]
        public async Task CreateMovieScreening([FromBody] ScreeningDTO screening)
        {
            await _managerService.CreateMovieScreeningAsync(screening);
        }

        [HttpPost]
        [Route("update")]
        public async Task UpdateScreening([FromBody] ScreeningDTO screening)
        {
            await _managerService.UpdateMovieScreeningAsync(screening);
        }

        [HttpPost]
        [Route("delete/{screeningID}")]
        public async Task DeleteMovieScreening(int screeningID)
        {
            await _managerService.DeleteMovieScreeningAsync(screeningID);
        }


        // Employees
        [HttpGet]
        [Route("employees")]
        public async Task<List<EmployeeDTO>> GetEmployees()
        {

            return await _managerService.GetEmployeesAsync();
        }

        [HttpGet]
        [Route("employees/{employeeID}")]
        public async Task<EmployeeDTO> GetEmployee(int employeeID)
        {
            return await _managerService.GetEmployeeAsync(employeeID);
        }


        // Rooms
        [HttpGet]
        [Route("rooms/{roomID}")]
        public async Task<RoomDTO> GetRoom(int roomID)
        {
            return await _managerService.GetRoomAsync(roomID);
        }

        [HttpGet]
        [Route("rooms")]
        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _managerService.GetRoomsAsync();
        }
    }
}
