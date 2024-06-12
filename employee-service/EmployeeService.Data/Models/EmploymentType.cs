using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Data.Models
{
    public class EmploymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }
        public string? Description { get; set; }
        public ICollection<Employee>? Employees { get; }
    }
}
