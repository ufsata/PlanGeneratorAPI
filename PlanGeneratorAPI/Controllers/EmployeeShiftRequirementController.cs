using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PlanGeneratorDto.EmployeeShiftRequirements;
using PlanGeneratorRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanGeneratorAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class EmployeeShiftRequirementController : Controller
    {
        private readonly IEmployeeShiftRequirementRepository _employeeShiftRequirementRepository;

        public EmployeeShiftRequirementController(IEmployeeShiftRequirementRepository employeeShiftRequirementRepository)
        {
            _employeeShiftRequirementRepository = employeeShiftRequirementRepository;
        }

        [HttpGet]
        public async Task<ICollection<EmpShiftRequiremetsDto>> GetShiftRequirements()
        {
            var listOfAbsenceDates = await _employeeShiftRequirementRepository.GetListOfEmpShiftRequirements();

            return listOfAbsenceDates;
        }

        [HttpGet("{id}")]
        public async Task<ICollection<EmpShiftRequiremetsDto>> GetShiftRequirementsById(int id)

        {
            var listOfAbsenceDates = await _employeeShiftRequirementRepository.GetEmpShiftRequirementsById(id);

            return listOfAbsenceDates;
        }

        [HttpPost]
        public async Task<ActionResult<EmpShiftRequiremetsDto>> PostShiftRequirement([FromBody]EmpShiftRequiremetsDto empShiftRequirement)
        {
            await _employeeShiftRequirementRepository.AddEmpShiftRequirements(empShiftRequirement);

            return CreatedAtAction("GetShiftRequirementsById", new { id = empShiftRequirement.Id }, empShiftRequirement);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmpShiftRequiremetsDto>> UpdateShiftRequirement([FromBody]EmpShiftRequiremetsDto empShiftRequirement)
        {
            try
            {
                await _employeeShiftRequirementRepository.UpdateEmpShiftRequirements(empShiftRequirement);
                return NoContent();
            }
            catch
            {
                throw new ArgumentException("No such Shift Requirement");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpShiftRequiremetsDto>> DeleteShiftRequirementById(int id)
        {
            var shiftRequirementToReturn = await _employeeShiftRequirementRepository.DeleteEmpShiftRequirements(id);

            if (shiftRequirementToReturn == null)
            {
                return NotFound();
            }

            return Ok(shiftRequirementToReturn);
        }
    }
}
