using EmployeeService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data
{
    public interface IEmployeeContext : IDisposable
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<EmploymentType> EmploymentTypes { get; set; }

        int SaveChanges();
    }
}
