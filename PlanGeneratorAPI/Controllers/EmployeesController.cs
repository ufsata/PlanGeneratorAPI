using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanGeneratorDto.Employee;
using PlanGeneratorRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PlanGeneratorAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController( IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ICollection<EmployeeDto>> GetEmployeesShort()
        {
            var listOfEmployeesShort = await _employeeRepository.GetListOfEmployeesShort();

            return listOfEmployeesShort;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeebyId(int id)
        {
            var employeeToReturn = await _employeeRepository.GetEmployeeById(id);

            if (employeeToReturn == null)
            {
                return NotFound();
            }

            return Ok(employeeToReturn);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> PostEmployee([FromBody]EmployeeDto employee)
        {
            await _employeeRepository.AddEmployee(employee);

            return CreatedAtAction("GetEmployeebyId", new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee([FromBody]EmployeeDto employee)
        {
            try
            {
                await _employeeRepository.UpdateEmployee(employee);
                return NoContent();
            }
            catch
            {
                throw new ArgumentException("No such user");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployeebyId(int id)
        {
            var employeeToReturn = await _employeeRepository.DeleteEmployee(id);

            if (employeeToReturn == null)
            {
                return NotFound();
            }

            return Ok(employeeToReturn);
        }
    }
}
