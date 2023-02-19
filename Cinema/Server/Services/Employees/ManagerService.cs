using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Services.Employees
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerService _managerService;

        public ManagerService(IManagerService managerService) 
        {
            _managerService = managerService;
        }

        public async Task<ScreeningDTO> AddScreeningAsync(ScreeningDTO screening)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteScreening(int screeningID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoomDTO>> GetRoomsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRoom(RoomDTO roomDTO)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateScreeningAsync(ScreeningDTO screening)
        {
            throw new NotImplementedException();
        }

    }
}
