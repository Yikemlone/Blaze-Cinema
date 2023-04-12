using Cinema.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DataAccess.Services.RoomsServices
{
    public interface IRoomsService
    {
        public Task<List<RoomDTO>> GetRoomsAsync();
        public Task<RoomDTO> GetRoomAsync(int roomID);
        public Task UpdateRoomAsync(RoomDTO roomDTO);
    }
}
