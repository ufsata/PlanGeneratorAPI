using PlanGeneratorDto.Employee;
using PlanGeneratorDto.EmployeeAbsenceDate;
using PlanGeneratorDto.EmployeeShiftRequirements;
using PlanGeneratorDto.WorkPlan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanGeneratorRepository.Contracts
{
    public interface IWorkPlanGeneratorRepository
    {
        Task<List<EmpAbsenceDateDto>> GetListOfEmpAbsenceDatesByDate(DateTime startDate, DateTime endDate);
        Task<List<EmpShiftRequiremetsDto>> GetListOfEmpShiftRequirementsByDate(DateTime startDate, DateTime endDate);
        Task<WorkPlanDto> GenerateWorkPlan(DateTime startDate, DateTime endDate);

    }
}
