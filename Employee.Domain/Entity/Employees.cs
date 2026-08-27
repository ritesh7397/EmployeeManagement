using System.ComponentModel.DataAnnotations;

namespace Employee.Domain.Entity
{
    public class Employees : BaseAuditEntity
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        [Range(1, 1000000)]
        public int EmployeeSalary { get; set; }

        public string? EmployeeDescription { get; set; }
    }
}