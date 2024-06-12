using EmployeeService.Data.Models;
using EmployeeService.Domain;
using EmployeeService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace EmployeeService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmploymentTypeController : ControllerBase
    {
        IEmploymentTypeService _employmentTypeService;

        public EmploymentTypeController(IEmploymentTypeService employmentTypeService)
        {
            _employmentTypeService = employmentTypeService;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<EmploymentType>> GetAll()
        {
            return await _employmentTypeService.GetAllAsync();
        }
    }
}
