namespace EmployeeService.Domain
{
    public class EmployeeRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? JoinedOn { get; set; }
        public int? EmploymentTypeId { get; set; }
    }
}
