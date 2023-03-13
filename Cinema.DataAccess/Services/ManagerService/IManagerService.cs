using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.ManagerService
{
    public interface IManagerService
    {
        // Manager Functions
        // Limit with authorization
        public Task CreateMovieScreeningAsync(ScreeningDTO screening);
        public Task UpdateMovieScreeningAsync(ScreeningDTO screening);
        public Task DeleteMovieScreeningAsync(int screeningID);



        public Task UpdateRoomAsync(RoomDTO roomDTO);
        public Task<List<EmployeeDTO>> GetEmployeesAsync();

        public Task<EmployeeDTO> GetEmployeeAsync(int empolyeeID);

        public Task<RoomDTO> GetRoomAsync(int roomID);

        public Task<List<RoomDTO>> GetRoomsAsync();
    }
}
