using Cinema.DataAccess.Services.UnitOfWorkServices;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ManagerController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Screenings
        [HttpPost]
        [Route("create")]
        public async Task CreateMovieScreening([FromBody] ScreeningDTO screening)
        {
            await _unitOfWork.ManagerService.CreateMovieScreeningAsync(screening);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Route("update")]
        public async Task UpdateScreening([FromBody] ScreeningDTO screening)
        {
            await _unitOfWork.ManagerService.UpdateMovieScreeningAsync(screening);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Route("delete/{screeningID}")]
        public async Task DeleteMovieScreening(Guid screeningID)
        {
            await _unitOfWork.ManagerService.DeleteMovieScreeningAsync(screeningID);
            await _unitOfWork.SaveAsync();
        }


        // Employees
        [HttpGet]
        [Route("employees")]
        public async Task<List<EmployeeDTO>> GetEmployees()
        {

            return await _unitOfWork.ManagerService.GetEmployeesAsync();
        }

        [HttpGet]
        [Route("employees/{employeeID}")]
        public async Task<EmployeeDTO> GetEmployee(int employeeID)
        {
            return await _unitOfWork.ManagerService.GetEmployeeAsync(employeeID);
        }


        // Rooms
        [HttpGet]
        [Route("rooms/{roomID}")]
        public async Task<RoomDTO> GetRoom(int roomID)
        {
            return await _unitOfWork.ManagerService.GetRoomAsync(roomID);
        }

        [HttpGet]
        [Route("rooms")]
        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _unitOfWork.ManagerService.GetRoomsAsync();
        }

        [HttpPost]
        [Route("updateRoom")]
        public async Task UpdateRoom([FromBody] RoomDTO room)
        {
            await _unitOfWork.ManagerService.UpdateRoomAsync(room);
            await _unitOfWork.SaveAsync();
        }
    }
}
