using Azure.Core;
using EmployeeService.Data;
using EmployeeService.Data.Models;
using EmployeeService.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Services
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        IEmployeeContext _context;
        public EmploymentTypeService(IEmployeeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmploymentType>> GetAllAsync()
        {
            return await _context.EmploymentTypes.ToListAsync();
        }
    }
}
