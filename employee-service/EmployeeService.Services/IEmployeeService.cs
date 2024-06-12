using EmployeeService.Data.Models;
using EmployeeService.Domain;

namespace EmployeeService.Services
{
    public interface IEmployeeService
    {
        Task AddEmployeeAsync(EmployeeRequest request);
        Task DeleteEmployeeAsync(int id);
        Task<IEnumerable<EmployeeResponse>> GetEmployeesAsync(EmployeeRequest request);
        Task UpdateEmployeeAsync(int id, EmployeeRequest request);
    }
}
