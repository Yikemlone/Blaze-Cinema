using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services.ManagerServices
{
    public class ManagerService : IManagerService
    {
        private readonly CinemaDBContext _context;

        public ManagerService(CinemaDBContext context)
        {
            _context = context;
        }

        // Screenings
        public async Task CreateMovieScreeningAsync(ScreeningDTO screening)
        {
            var newScreening = new Screening()
            {
                DateTime = screening.DateTime,
                MovieID = screening.MovieID,
                RoomID = screening.RoomID
            };

            await _context.AddAsync(newScreening);
            await _context.SaveChangesAsync();

            var seats = await _context.Seats
                .Where(s => s.RoomID == newScreening.RoomID)
                .Select(s => s)
                .ToListAsync();

            var screeningSeats = new List<SeatScreening>();

            foreach (var seat in seats)
            {
                screeningSeats.Add(new SeatScreening
                {
                    ScreeningID = newScreening.ID,
                    Booked = false,
                    SeatID = seat.ID
                });
            }

            await _context.AddRangeAsync(screeningSeats);
        }

        public async Task UpdateMovieScreeningAsync(ScreeningDTO screening)
        {
            var oldScreening = await _context.Screenings
                .Where(m => m.ID == screening.ID)
                .Select(m => m)
                .FirstOrDefaultAsync();

            if (oldScreening == null) return;

            oldScreening.DateTime = screening.DateTime;
            oldScreening.MovieID = screening.MovieID;
            oldScreening.RoomID = screening.RoomID;

            var seats = await _context.Seats
                .Where(s => s.RoomID == screening.RoomID)
                .Select(s => s)
                .ToListAsync();

            var newScreeningSeats = new List<SeatScreening>();

            foreach (var seat in seats)
            {
                newScreeningSeats.Add(new SeatScreening
                {
                    Booked = false,
                    ScreeningID = screening.ID,
                    SeatID = seat.ID,
                });
            }

            var oldScreeningsSeats= await _context.SeatScreenings
                .Where(s => s.ScreeningID == screening.ID)
                .Select(s => s)
                .ToListAsync();

            _context.SeatScreenings.RemoveRange(oldScreeningsSeats);
        }

        public async Task DeleteMovieScreeningAsync(int screeningID)
        {
            var screening = await _context.Screenings
                .Where(m => m.ID == screeningID)
                .Select(s => s)
                .FirstOrDefaultAsync();

            if (screening == null) return;

            var seatScreenings = await _context.SeatScreenings
                .Where(s => s.ScreeningID == screening.ID)
                .Select(s => s)
                .ToListAsync();

            _context.Screenings.Remove(screening);
            _context.SeatScreenings.RemoveRange(seatScreenings);
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
