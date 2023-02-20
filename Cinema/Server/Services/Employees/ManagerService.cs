using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Services.Employees
{
    public class ManagerService : IManagerService
    {
        private readonly CinemaDBContext _context;

        public ManagerService(CinemaDBContext context) 
        {
            _context = context;
        }

        public async Task<ScreeningDTO> AddScreeningAsync(ScreeningDTO screening)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteScreeningAsync(int screeningID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoomDTO>> GetRoomsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRoomAsync(RoomDTO roomDTO)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateScreeningAsync(ScreeningDTO screening)
        {
            throw new NotImplementedException();
        }

    }
}
