using EmployeeService.Data.Models;
using EmployeeService.Domain;

namespace EmployeeService.Services
{
    public interface IEmploymentTypeService
    {
        Task<IEnumerable<EmploymentType>> GetAllAsync();
    }
}
