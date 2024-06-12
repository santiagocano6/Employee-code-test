using EmployeeService.Data.Models;
using EmployeeService.Domain;

namespace EmployeeService.Services
{
    public interface IEmployeeService : IDisposable
    {
        Task<List<Employee>> GetEmployeesAsync(EmployeeRequest request);
        void GetException();
    }
}
