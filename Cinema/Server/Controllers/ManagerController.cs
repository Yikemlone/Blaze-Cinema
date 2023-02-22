using Cinema.Server.Services.Employees;
using Cinema.Server.Services.Movies;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ManagerController
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet]
        [ResponseType(typeof(List<EmployeeDTO>))]
        [Route("employees")]
        public async Task<List<EmployeeDTO>> GetEmployees()
        {

            return await _managerService.GetEmployeesAsync();
        }
    }
}
