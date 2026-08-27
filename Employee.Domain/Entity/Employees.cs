
using System.ComponentModel.DataAnnotations;

namespace Employee.Domain.Entity
{
    public class Employees : BaseAuditEntity
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeSalary { get; set; }
        public string? EmployeeDescription { get; set; }
    }
}
