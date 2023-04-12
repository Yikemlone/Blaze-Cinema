using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CinemaDBContext _context;

        public EmployeeService(CinemaDBContext context)
        {
            _context = context;
        }



        // Employees
        public async Task<List<EmployeeDTO>> GetEmployeesAsync()
        {
            var employees = await _context.Employees
                .Select(m => new EmployeeDTO()
                {
                    ID = m.ID,
                    JobTitle = m.JobTitle,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Username = m.Username,
                    Password = m.Password
                })
                .ToListAsync();

            return employees;
        }

        public async Task<EmployeeDTO> GetEmployeeAsync(int employeeID)
        {
            var employee = await _context.Employees
                 .Where(m => m.ID == employeeID)
                 .Select(m => new EmployeeDTO()
                 {
                     ID = m.ID,
                     JobTitle = m.JobTitle,
                     FirstName = m.FirstName,
                     LastName = m.LastName,
                     Username = m.Username,
                     Password = m.Password
                 })
                 .FirstOrDefaultAsync();

            if (employee == null) return new EmployeeDTO();

            return employee;
        }


        // Rooms
        public async Task<RoomDTO> GetRoomAsync(int roomID)
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

        public async Task<List<RoomDTO>> GetRoomsAsync()
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
        
        public async Task UpdateRoomAsync(RoomDTO roomDTO)
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
