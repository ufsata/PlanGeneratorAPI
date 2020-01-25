using PlanGeneratorDataAccess.Entities;
using PlanGeneratorDto.EmployeeShiftRequirements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanGeneratorRepository.Contracts
{
    public interface IEmployeeShiftRequirementRepository
    {
        Task<List<EmpShiftRequiremetsDto>> GetListOfEmpShiftRequirements();
        Task<List<EmpShiftRequiremetsDto>> GetEmpShiftRequirementsById(int id);
        Task<EmployeeShiftRequirement> AddEmpShiftRequirements(EmpShiftRequiremetsDto empShiftRequirement);
        Task<EmployeeShiftRequirement> UpdateEmpShiftRequirements(EmpShiftRequiremetsDto empShiftRequirement);
        Task<EmployeeShiftRequirement> DeleteEmpShiftRequirements(int id);
    }
}
