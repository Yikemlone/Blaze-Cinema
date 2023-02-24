using Cinema.Shared.DTO;

namespace Cinema.Server.Services.Employees
{
    public interface IManagerService
    {
        // Manager Functions
        // Limit with authorization
        public Task CreateMovieScreeningAsync(ScreeningDTO screening);
        public Task UpdateMovieScreeningAsync(ScreeningDTO screening);
        public Task DeleteMovieScreeningAsync(int screeningID);


        public Task<List<RoomDTO>> GetRoomsAsync();
        public Task UpdateRoomAsync(RoomDTO roomDTO);
        public Task<List<EmployeeDTO>> GetEmployeesAsync();

        public Task<EmployeeDTO> GetEmployeeAsync(int empolyeeID);
    }
}
