using Cinema.Server.Models;
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


        public async Task<List<RoomDTO>> GetRoomsAsync()
        {
            throw new NotImplementedException();
        }

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
        // create screening
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
        //update movie screening
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

        // delete movie screening
        public async Task DeleteMovieScreeningAsync(int screeningID)
        {
            var screening = _context.Screenings.FirstOrDefault(x => x.ID == screeningID);
            if (screening != null)
            {
                _context.Screenings.Remove(screening);
                await _context.SaveChangesAsync();
            }
        }
    }
}
