using Employee.Domain.Entity;

namespace Employee.UI.Models
{
    public class EmployeeDetailViewModel
    {
        public List<Employees> List { get; set; }// List of all laptops to display in table

        public Employees Employee { get; set; }// Single laptop for edit/create form
    }
}
