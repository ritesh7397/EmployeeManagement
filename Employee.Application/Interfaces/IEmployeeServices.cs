

using Employee.Domain.Entity;

namespace Employee.Application.Interfaces
{
    public interface IEmployeeServices
    {
        Task<int> CreateAsync(Employees employees);
        Task<int> UpdateAsync(Employees employees);
        Task<int> DeleteAsync(int id);
        Task<List<Employees>> GetEmployeesAsync();
        Task<Employees> GetByIdAsync(int EmployeeId);

    }
}
