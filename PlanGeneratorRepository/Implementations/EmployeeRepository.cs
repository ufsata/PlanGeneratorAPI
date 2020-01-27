using Microsoft.EntityFrameworkCore;
using PlanGeneratorDataAccess;
using PlanGeneratorDataAccess.Entities;
using PlanGeneratorDto.Employee;
using PlanGeneratorRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanGeneratorRepository.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PlanGeneratorContext _context;

        public EmployeeRepository(PlanGeneratorContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDto>> GetListOfEmployeesShort()
        {
            return await _context.Employees.Select(e => new EmployeeDto { 
                Id = e.Id,
                Name = e.EmployeeName
            }).ToListAsync();
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {   
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id) ??
                throw new Exception("No such Employee");
           
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.EmployeeName
            };
        }

        public async Task<Employee> AddEmployee(EmployeeDto employee)
        {
            var newEmployee = new Employee
            {
                Id = employee.Id,
                EmployeeName = employee.Name
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee;
        }

        public async Task<Employee> UpdateEmployee(EmployeeDto employee)
        {
            var employeeForUpdate = new Employee
            {
                Id = employee.Id,
                EmployeeName = employee.Name
            };

            _context.Employees.Update(employeeForUpdate);
            await _context.SaveChangesAsync();

            return employeeForUpdate;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employeeForDelete = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id) ??
                throw new Exception("No such Employee");

            _context.Set<Employee>().Remove(employeeForDelete);
            await _context.SaveChangesAsync();

            return employeeForDelete;
        }
    }
}
