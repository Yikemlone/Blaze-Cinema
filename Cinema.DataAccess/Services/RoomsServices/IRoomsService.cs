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
        public Task<List<RoomDTO>> GetAllAsync();
        public Task<RoomDTO> GetAsync(int roomID);
        public Task UpdateAsync(RoomDTO roomDTO);
    }
}
