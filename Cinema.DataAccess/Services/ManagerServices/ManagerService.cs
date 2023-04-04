using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.Shared.DTO;

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

            var seats = _context.Seats
                .Where(s => s.RoomID == newScreening.RoomID)
                .Select(s => s)
                .ToList();

            await _context.AddAsync(newScreening);
            await _context.SaveChangesAsync();

            var screeningSeats = new List<SeatScreening>();

            foreach (var seat in seats)
            {
                screeningSeats.Add(new SeatScreening
                {
                    Booked = false,
                    ScreeningID = newScreening.ID,
                    SeatID = seat.ID,
                });
            }

            await _context.AddRangeAsync(screeningSeats);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieScreeningAsync(ScreeningDTO screening)
        {
            var oldScreening = _context.Screenings
                .Where(m => m.ID == screening.ID)
                .Select(m => m)
                .SingleOrDefault();

            if (oldScreening == null) return;

            oldScreening.DateTime = screening.DateTime;
            oldScreening.MovieID = screening.MovieID;
            oldScreening.RoomID = screening.RoomID;

            var seats = _context.Seats
                .Where(s => s.RoomID == screening.RoomID)
                .Select(s => s)
                .ToList();

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

            var oldScreeningsSeats= _context.SeatScreenings
                .Where(s => s.ID == screening.ID)
                .Select(s => s)
                .ToList();

            _context.SeatScreenings.RemoveRange(oldScreeningsSeats);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieScreeningAsync(int screeningID)
        {
            var screening = _context.Screenings
                .Where(m => m.ID == screeningID)
                .Select(s => s)
                .FirstOrDefault();

            if (screening == null) return;

            var seatScreenings = _context.SeatScreenings
                .Where(s => s.ID == screening.ID)
                .Select(s => s)
                .ToList();

            _context.Screenings.Remove(screening);
            _context.SeatScreenings.RemoveRange(seatScreenings);
            await _context.SaveChangesAsync();
        }


        // Employees
        public async Task<List<EmployeeDTO>> GetEmployeesAsync()
        {
            List<EmployeeDTO> employees = _context.Employees
                .Select(m => new EmployeeDTO()
                {
                    ID = m.ID,
                    JobTitle = m.JobTitle,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Username = m.Username,
                    Password = m.Password
                })
                .ToList();

            return employees;
        }

        public async Task<EmployeeDTO> GetEmployeeAsync(int employeeID)
        {
            var employee = _context.Employees
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
                 .SingleOrDefault();

            return employee;
        }


        // Rooms
        public async Task<RoomDTO> GetRoomAsync(int roomID)
        {
            var room = _context.Rooms
                 .Where(m => m.ID == roomID)
                 .Select(m => new RoomDTO()
                 {
                     ID = m.ID,
                     Decom = m.Decom,
                 })
                 .SingleOrDefault();

            return room;
        }

        public async Task<List<RoomDTO>> GetRoomsAsync()
        {
            List<RoomDTO> rooms = _context.Rooms
              .Select(m => new RoomDTO()
              {
                  ID = m.ID,
                  Decom = m.Decom,
              })
              .ToList();

            return rooms;
        }
        
        public async Task UpdateRoomAsync(RoomDTO roomDTO)
        {
            var oldRoom = _context.Rooms
               .Select(m => m)
               .Where(m => m.ID == roomDTO.ID)
               .SingleOrDefault();

            if (oldRoom == null) return;
            oldRoom.Decom = roomDTO.Decom;
            
            await _context.SaveChangesAsync();
        }

    }
}
