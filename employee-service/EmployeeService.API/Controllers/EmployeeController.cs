using EmployeeService.Data.Models;
using EmployeeService.Domain;
using EmployeeService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
        public async Task<IEnumerable<EmployeeResponse>> GetAllEmployees([FromQuery] EmployeeRequest request)
        {
            return await _employeeService.GetEmployeesAsync(request);
        }

        [HttpPost]
        public async Task PostEventAsync(EmployeeRequest request)
        {
            await _employeeService.AddEmployeeAsync(request);
        }

        [HttpPut("{id:int}")]
        public async Task PutEventAsync(int id, EmployeeRequest request)
        {
            await _employeeService.UpdateEmployeeAsync(id, request);
        }

        [HttpDelete("{id:int}")]
        public async Task DeleteEventAsync(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
        }
    }
}
