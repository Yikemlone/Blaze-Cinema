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

        public Task<ScreeningDTO> CreateMovieScreeningAsync(ScreeningDTO screening)
        {
            throw new NotImplementedException();
        }
    }
}
