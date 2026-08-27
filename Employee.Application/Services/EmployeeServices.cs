using Employee.Application.Interfaces;
using Employee.Domain.Entity;
using Employee.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace Employee.Application.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly AppDBContext _appDBContext;

        public EmployeeServices(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<int> CreateAsync(Employees employees)
        {
            await _appDBContext.AddAsync(employees);
            employees.IsActive = true;
            employees.CreatedOn = DateTime.UtcNow;
            employees.CreatedBy = 1;
            employees.ModifiedOn = DateTime.UtcNow;
            employees.ModifiedBy = 1;

            return await _appDBContext.SaveChangesAsync();

        }

        public async Task<List<Employees>> GetEmployeesAsync()
        {
            return await _appDBContext.Employee.ToListAsync();
        }

        public async Task<Employees> GetByIdAsync(int EmployeeId)
        {
            return await _appDBContext.Employee.FindAsync(EmployeeId);
        }

        public async Task<int> UpdateAsync(Employees employees)
        {
            var employee = await _appDBContext.Employee.FindAsync(employees.EmployeeId);

            if (employee == null)
                return 0;
            
            employee.EmployeeName = employees.EmployeeName;
            employee.EmployeeSalary = employees.EmployeeSalary;
            employee.EmployeeDescription = employees.EmployeeDescription; 
            employee.IsActive = true;
            //employee.CreatedOn = DateTime.UtcNow;
            //employee.CreatedBy = 1;
            employee.ModifiedOn = DateTime.UtcNow;
            employee.ModifiedBy = 1;


            //_appDBContext.Update(employee);
            return await _appDBContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var employee = await _appDBContext.Employee.FindAsync(id);
            if (employee == null)
                return 0;

            _appDBContext.Employee.Remove(employee);
            return await _appDBContext.SaveChangesAsync();

        }

    }
}
