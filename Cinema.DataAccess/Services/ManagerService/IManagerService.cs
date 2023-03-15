using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.ManagerService
{
    public interface IManagerService
    {
        // Manager Functions
        // Limit with authorization
        
        // Screenings
        public Task CreateMovieScreeningAsync(ScreeningDTO screening);
        public Task UpdateMovieScreeningAsync(ScreeningDTO screening);
        public Task DeleteMovieScreeningAsync(int screeningID);

        // Employees
        public Task<List<EmployeeDTO>> GetEmployeesAsync();
        public Task<EmployeeDTO> GetEmployeeAsync(int empolyeeID);

        // Rooms
        public Task UpdateRoomAsync(RoomDTO roomDTO);
        public Task<RoomDTO> GetRoomAsync(int roomID);
        public Task<List<RoomDTO>> GetRoomsAsync();
    }
}
