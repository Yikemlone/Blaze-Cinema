using Cinema.DataAccess.Services.UnitOfWorkServices;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Controllers
{
    [Authorize(Policy = "IsManager")]
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
        public async Task CreateScreening([FromBody] ScreeningDTO screening)
        {
            await _unitOfWork.ScreeningService.AddAsync(screening);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Route("update")]
        public async Task UpdateScreening([FromBody] ScreeningDTO screening)
        {
            await _unitOfWork.ScreeningService.UpdateAsync(screening);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Route("delete")]
        public async Task DeleteScreening([FromBody] ScreeningDTO Screeningscreening)
        {
            await _unitOfWork.ScreeningService.DeleteAsync(Screeningscreening);
            await _unitOfWork.SaveAsync();
        }

        // Employees
        //[HttpGet]
        //[Route("employees")]
        //public async Task<List<EmployeeDTO>> GetEmployees()
        //{
        //    return await _unitOfWork.ManagerService.GetEmployeesAsync();
        //}

        //[HttpGet]
        //[Route("employees/{employeeID}")]
        //public async Task<EmployeeDTO> GetEmployee(int employeeID)
        //{
        //    return await _unitOfWork.ManagerService.GetEmployeeAsync(employeeID);
        //}


        // Rooms
        [HttpGet]
        [Route("rooms/{roomID}")]
        public async Task<RoomDTO> GetRoom(int roomID)
        {
            return await _unitOfWork.RoomsService.GetAsync(roomID);
        }

        [HttpGet]
        [Route("rooms")]
        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _unitOfWork.RoomsService.GetAllAsync();
        }

        [HttpPost]
        [Route("updateRoom")]
        public async Task UpdateRoom([FromBody] RoomDTO room)
        {
            await _unitOfWork.RoomsService.UpdateAsync(room);
            await _unitOfWork.SaveAsync();
        }
    }
}
