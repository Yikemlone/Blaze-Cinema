using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly CinemaDBContext _context;

        public ManagerService(CinemaDBContext context)
        {
            _context = context;
        }

        // TODO: Updaete decom status of the room
        public async Task UpdateRoomAsync(RoomDTO roomDTO)
        {
            throw new NotImplementedException();
        }

        //Get all employees
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

                }).ToList();

            return employees;
        }

        //Get employee
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

        // Create screening
        public async Task CreateMovieScreeningAsync(ScreeningDTO screening)
        {
            var newScreening = new Screening()
            {
                ID = screening.ID,
                DateTime = screening.DateTime,
                MovieID = screening.MovieID,
                RoomID = screening.RoomID

            };

            await _context.AddAsync(newScreening);
            await _context.SaveChangesAsync();
        }

        // Update movie screening
        public async Task UpdateMovieScreeningAsync(ScreeningDTO screening)
        {
            var oldScreening = _context.Screenings
             .Select(m => m)
             .Where(m => m.ID == screening.ID)
             .SingleOrDefault();

            if (oldScreening == null) return;

            oldScreening.ID = screening.ID;
            oldScreening.DateTime = screening.DateTime;
            oldScreening.MovieID = screening.MovieID;
            oldScreening.RoomID = screening.RoomID;

            await _context.SaveChangesAsync();
        }

        // Delete movie screening
        public async Task DeleteMovieScreeningAsync(int screeningID)
        {
            var screening = _context.Screenings.FirstOrDefault(x => x.ID == screeningID);
            if (screening != null)
            {
                _context.Screenings.Remove(screening);
                await _context.SaveChangesAsync();
            }
        }

        //Get room
        public async Task<RoomDTO> GetRoomAsync(int roomID)
        {
            var room = _context.Rooms
                 .Where(m => m.ID == roomID)
                 .Select(m => new RoomDTO()
                 {
                     ID = m.ID,
                     Decom = m.Decom,
                     SeatQty = m.SeatQty

                 })
                 .SingleOrDefault();

            return room;
        }

        //Get rooms 
        public async Task<List<RoomDTO>> GetRoomsAsync()
        {
            List<RoomDTO> rooms = _context.Rooms
              .Select(m => new RoomDTO()
              {
                  ID = m.ID,
                  Decom = m.Decom,
                  SeatQty = m.SeatQty

              }).ToList();

            return rooms;
        }

        //Get Seat
        public async Task<SeatDTO> GetSeatAsync(int seatID)
        {
            var seat = _context.Seats
                 .Where(m => m.ID == seatID)
                 .Select(m => new SeatDTO()
                 {
                     ID = m.ID,
                     SeatNumber = m.SeatNumber,
                     DisabiltySeat = m.DisabiltySeat

                 })
                 .SingleOrDefault();

            return seat;
        }

        //Get Seats
        public async Task<List<SeatDTO>> GetSeatsAsync()
        {
            List<SeatDTO> seats = _context.Seats
              .Select(m => new SeatDTO()
              {
                  ID = m.ID,
                  SeatNumber = m.SeatNumber,
                  DisabiltySeat = m.DisabiltySeat

              }).ToList();

            return seats;
        }
    }
}
