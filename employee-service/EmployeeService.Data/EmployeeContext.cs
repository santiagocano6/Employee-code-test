using EmployeeService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data
{
    public class EmployeeContext : DbContext, IEmployeeContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmploymentType>()
                .HasData(new EmploymentType
                {
                    Id = (int)Enums.EmploymentTypes.Permanent,
                    Description = "Permanent"
                });
            modelBuilder.Entity<EmploymentType>()
               .HasData(new EmploymentType
               {
                   Id = (int)Enums.EmploymentTypes.Freelance,
                   Description = "Freelance"
               });
            modelBuilder.Entity<EmploymentType>()
               .HasData(new EmploymentType
               {
                   Id = (int)Enums.EmploymentTypes.Intern,
                   Description = "Intern"
               });

            modelBuilder.Entity<Employee>()
                .HasData(new Employee
                {
                    Id = 1,
                    FirstName = "Sherlock",
                    LastName = "Holmes",
                    Email = "holmes@detectives.org",
                    JoinedOn = new DateTime(2011, 6, 5),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    EmploymentTypeId = (int)Enums.EmploymentTypes.Permanent
                });
            modelBuilder.Entity<Employee>()
                .HasData(new Employee
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Marple",
                    Email = "marple@detectives.org",
                    JoinedOn = new DateTime(2013, 11, 14),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    EmploymentTypeId = (int)Enums.EmploymentTypes.Freelance
                });
            modelBuilder.Entity<Employee>()
                .HasData(new Employee
                {
                    Id = 3,
                    FirstName = "Hercule",
                    LastName = "Poirot",
                    Email = "poirot@detectives.org",
                    JoinedOn = new DateTime(2012, 8, 9),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    EmploymentTypeId = (int)Enums.EmploymentTypes.Permanent
                });
            modelBuilder.Entity<Employee>()
                .HasData(new Employee
                {
                    Id = 4,
                    FirstName = "Nancy",
                    LastName = "Drew",
                    Email = "drew@detectives.org",
                    JoinedOn = new DateTime(2024, 3, 4),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    EmploymentTypeId = (int)Enums.EmploymentTypes.Intern
                });
            modelBuilder.Entity<Employee>()
                .HasData(new Employee
                {
                    Id = 5,
                    FirstName = "Jessica",
                    LastName = "Fletcher",
                    Email = "fletcher@detectives.org",
                    JoinedOn = new DateTime(2018, 5, 12),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    EmploymentTypeId = (int)Enums.EmploymentTypes.Freelance
                });
            modelBuilder.Entity<Employee>()
                .HasData(new Employee
                {
                    Id = 6,
                    FirstName = "Frank",
                    LastName = "Columbo",
                    Email = "columbo@detectives.org",
                    JoinedOn = new DateTime(2016, 9, 7),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    EmploymentTypeId = (int)Enums.EmploymentTypes.Permanent
                });
        }
    }
}
