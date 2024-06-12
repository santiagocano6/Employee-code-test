using Azure.Core;
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
        }

        public async Task<IEnumerable<EmployeeResponse>> GetEmployeesAsync(EmployeeRequest request)
        {
            var employeeQuery = _context.Employees.AsQueryable().Include(x => x.EmploymentType);

            var response = await employeeQuery.ToListAsync();

            return response.ConvertToReponse();
        }

        public async Task AddEmployeeAsync(EmployeeRequest request)
        {
            var employee = request.ConvertToModel();
            await _context.Employees.AddAsync(employee);
            _context.SaveChanges();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeRequest request)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {
                employee.FirstName = request.FirstName;
                employee.LastName = request.LastName;
                employee.Email = request.Email;
                employee.EmploymentTypeId = request.EmploymentTypeId.GetValueOrDefault((int)Enums.EmploymentTypes.Permanent);
                employee.JoinedOn = request.JoinedOn.GetValueOrDefault(DateTime.Now);
                employee.ModifiedOn = DateTime.Now;
                _context.Employees.Update(employee);

                _context.SaveChanges();
            }
        }

    }
}
