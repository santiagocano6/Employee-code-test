using EmployeeService.Data;
using EmployeeService.Data.Models;
using EmployeeService.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeContext _context;
        public EmployeeService(IEmployeeContext context)
        {
            _context = context;
            OnSaveMessageEvent += OnSaveMessageHandler;
        }

        public void Dispose()
        {
        }

        public event EventHandler<string> OnSaveMessageEvent;

        protected virtual void OnSaveMessageHandler(object? sender, string message)
        {
            //Save message into logs
            Console.WriteLine(message);
        }


        public async Task<List<Employee>> GetEmployeesAsync(EmployeeRequest request)
        {
            try
            {
                var employeeQuery = _context.Employees.AsQueryable();

                var response = await employeeQuery.ToListAsync();
                OnSaveMessageEvent.Invoke(this, $"GetEmployeesAsync: {response.Count} employees retrieved");

                return response;
            }
            catch(Exception ex)
            {
                OnSaveMessageEvent.Invoke(this, $"GetEmployeesAsync: {ex.Message}");
                throw;
            }
        }

        public void GetException()
        {
            throw new NotImplementedException();
        }

    }
}
