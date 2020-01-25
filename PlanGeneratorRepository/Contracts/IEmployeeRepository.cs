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
        Task<List<EmployeeDto>> GetListOfEmployeesShort();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<Employee> AddEmployee(EmployeeDto employee);
        Task<Employee> UpdateEmployee(EmployeeDto employee);
        Task<Employee> DeleteEmployee(int id);
    }
}
