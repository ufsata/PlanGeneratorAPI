using PlanGeneratorDataAccess.Entities;
using PlanGeneratorDto.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanGeneratorRepository.Contracts
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDto>> GetListOfEmployeesShort(string userId);
        Task<EmployeeDto> GetEmployeeById(int id, string userId);
        Task<Employee> AddEmployee(EmployeeDto employee, string userId);
        Task<Employee> UpdateEmployee(EmployeeDto employee, string userId);
        Task<Employee> DeleteEmployee(int id, string userId);
    }
}
