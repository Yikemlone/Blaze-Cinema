using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services.EmployeeServices
{
    public class EmployeeService
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
    }
}
