using Cinema.DataAccess.Context;
using Cinema.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services.RoomsServices
{
    public class RoomService : IRoomsService
    {
        private readonly CinemaDBContext _context;
        public RoomService(CinemaDBContext context) 
        {
            _context = context;
        }

        public async Task<RoomDTO> GetAsync(int roomID)
        {
            var room = await _context.Rooms
                 .Where(m => m.ID == roomID)
                 .Select(m => new RoomDTO()
                 {
                     ID = m.ID,
                     Decom = m.Decom,
                 })
                 .FirstOrDefaultAsync();

            if (room == null) return new RoomDTO();

            return room;
        }

        public async Task<List<RoomDTO>> GetAllAsync()
        {
            var rooms = await _context.Rooms
              .Select(m => new RoomDTO()
              {
                  ID = m.ID,
                  Decom = m.Decom,
              })
              .ToListAsync();

            return rooms;
        }

        public async Task UpdateAsync(RoomDTO roomDTO)
        {
            var oldRoom = await _context.Rooms
               .Select(m => m)
               .Where(m => m.ID == roomDTO.ID)
               .FirstOrDefaultAsync();

            if (oldRoom == null) return;
            oldRoom.Decom = roomDTO.Decom;
        }
    }
}
