using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userMng;
        
        public EmployeesController( IEmployeeRepository employeeRepository, UserManager<IdentityUser> userMng)
        {
            _employeeRepository = employeeRepository;
            _userMng = userMng;
        }

        [HttpGet]
        public async Task<ICollection<EmployeeDto>> GetEmployeesShort()
        {
            var listOfEmployeesShort = await _employeeRepository.GetListOfEmployeesShort(_userMng.GetUserId(User));

            return listOfEmployeesShort;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeebyId(int id)
        {
            var employeeToReturn = await _employeeRepository.GetEmployeeById(id, _userMng.GetUserId(User));

            if (employeeToReturn == null)
            {
                return NotFound();
            }

            return Ok(employeeToReturn);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> PostEmployee([FromBody]EmployeeDto employee)
        {
            await _employeeRepository.AddEmployee(employee, _userMng.GetUserId(User));

            return CreatedAtAction("GetEmployeebyId", new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee([FromBody]EmployeeDto employee)
        {
            try
            {
                await _employeeRepository.UpdateEmployee(employee, _userMng.GetUserId(User));
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
            var employeeToReturn = await _employeeRepository.DeleteEmployee(id, _userMng.GetUserId(User));

            if (employeeToReturn == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
