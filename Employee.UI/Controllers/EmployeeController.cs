using Employee.Application.Interfaces;
using Employee.Domain.Entity;
using Employee.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }
        public async Task<IActionResult> Index()
        {
            var model = new EmployeeDetailViewModel
            {
                List = await _employeeServices.GetEmployeesAsync(),
                Employee = new Employees()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employees employees)
        {
            if(employees.EmployeeId != 0)
            {
                await _employeeServices.UpdateAsync(employees);
            }
            else
            {
                await _employeeServices.CreateAsync(employees);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete (int id)
        {
            await _employeeServices.DeleteAsync(id);
            return RedirectToAction("Index");   
        }

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = new EmployeeDetailViewModel
            {
                List = await _employeeServices.GetEmployeesAsync(),
                Employee = await _employeeServices.GetByIdAsync(id)
            };
            return View("Index", model);
        }
        public async Task<IActionResult> Search(string name)
        {
            var employees = await _employeeServices.GetEmployeesAsync();

            if (!string.IsNullOrWhiteSpace(name))
            {
                employees = employees
                    .Where(e => e.EmployeeName.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var model = new EmployeeDetailViewModel
            {
                List = employees,
                Employee = new Employees()
            };

            return View("Index", model);
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeServices.GetEmployeesAsync();

            var model = new EmployeeDetailViewModel
            {
                //List = employees.OrderBy(e => e.EmployeeName).ToList(),
                //List = employees.OrderBy(e => e.EmployeeName).ToList(),
                //List = employees.OrderBy(e => e.EmployeeName).ToList(),
                //List = employees.OrderBy(e => e.EmployeeName).ToList(),

                List = employees.OrderByDescending(e => e.EmployeeName).ToList(),
                Employee = new Employees()

            };

            return View(model);
        }
    }
}
