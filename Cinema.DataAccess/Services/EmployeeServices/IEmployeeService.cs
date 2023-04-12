using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.EmployeeServices
{
    public interface IEmployeeService 
    {
        // Employees
        public Task<List<EmployeeDTO>> GetEmployeesAsync();
        public Task<EmployeeDTO> GetEmployeeAsync(int empolyeeID);
    }
}
