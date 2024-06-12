using EmployeeService.Data.Models;
using EmployeeService.Domain;
using EmployeeService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet(Name = "GetEmployees")]
        public async Task<IEnumerable<Employee>> GetAllEmployees([FromQuery] EmployeeRequest request)
        {
            return await _employeeService.GetEmployeesAsync(request);
        }
    }
}
