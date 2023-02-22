using Cinema.Shared.DTO;

namespace Cinema.Server.Services.Employees
{
    public interface IManagerService
    {
        // Manager Functions
        // Limit with authorization
        public Task<ScreeningDTO> AddScreeningAsync(ScreeningDTO screening);
        public Task UpdateScreeningAsync(ScreeningDTO screening);
        public Task DeleteScreeningAsync(int screeningID);


        public Task<List<RoomDTO>> GetRoomsAsync();
        public Task UpdateRoomAsync(RoomDTO roomDTO);
        public Task<List<EmployeeDTO>> GetEmployeesAsync();
    }
}
