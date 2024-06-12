using EmployeeService.Data.Models;

namespace EmployeeService.Domain
{
    public static class Extensions
    {
        public static IEnumerable<EmployeeResponse> ConvertToReponse(this List<Employee> employees)
        {
            return employees.Select(employee => new EmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                CreatedOn = employee.CreatedOn,
                EmploymentTypeId = employee.EmploymentTypeId,
                ModifiedOn = employee.ModifiedOn,
                JoinedOn = employee.JoinedOn, 
                EmploymentType = employee.EmploymentType == null ? string.Empty : employee.EmploymentType.Description
            });
        }

        public static Employee ConvertToModel(this EmployeeRequest employee)
        {
            return new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                EmploymentTypeId = employee.EmploymentTypeId.GetValueOrDefault(1),
                JoinedOn = employee.JoinedOn.GetValueOrDefault(DateTime.Now)
            };
        }
    }
}
