using Microsoft.AspNetCore.Mvc;
using PlanGeneratorDto.EmployeeAbsenceDate;
using PlanGeneratorRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanGeneratorAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesAbsenceDatesController : Controller
    {
        private readonly IEmployeeAbsenceDateRepository _employeeAbsenceDateRepository;

        public EmployeesAbsenceDatesController(IEmployeeAbsenceDateRepository employeeAbsenceDateRepository)
        {
            _employeeAbsenceDateRepository = employeeAbsenceDateRepository;
        }

        [HttpGet]
        public async Task<ICollection<EmpAbsenceDateDto>> GetAbsenceDates()
        {
            var listOfAbsenceDates = await _employeeAbsenceDateRepository.GetListOfEmpAbsenceDates();

            return listOfAbsenceDates;
        }

        [HttpGet("{id}")]
        public async Task<ICollection<EmpAbsenceDateDto>> GetAbsenceDatesById(int id)
        
        {
            var listOfAbsenceDates = await _employeeAbsenceDateRepository.GetEmpAbsenceDatesById(id);

            return listOfAbsenceDates;
        }

        [HttpPost]
        public async Task<ActionResult<EmpAbsenceDateDto>> PosttAbsenceDate([FromBody]EmpAbsenceDateDto empAbsDate)
        {
            await _employeeAbsenceDateRepository.AddEmpAbsenceDate(empAbsDate);

            return CreatedAtAction("GetAbsenceDatesById", new { id = empAbsDate.Id }, empAbsDate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmpAbsenceDateDto>> UpdatetAbsenceDate([FromBody]EmpAbsenceDateDto empAbsDate)
        {
            try
            {
                await _employeeAbsenceDateRepository.UpdateEmpAbsenceDate(empAbsDate);
                return NoContent();
            }
            catch
            {
                throw new ArgumentException("No such Absence Date");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpAbsenceDateDto>> DeletetAbsenceDateById(int id)
        {
            var absenceDateToReturn = await _employeeAbsenceDateRepository.DeleteEmpAbsenceDate(id);

            if (absenceDateToReturn == null)
            {
                return NotFound();
            }

            return Ok(absenceDateToReturn);
        }
    }
}
