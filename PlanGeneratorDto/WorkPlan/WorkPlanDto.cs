using PlanGeneratorDto.Employee;
using PlanGeneratorDto.EmployeeAbsenceDate;
using PlanGeneratorDto.EmployeeShiftRequirements;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanGeneratorDto.WorkPlan
{
    public class WorkPlanDto
    {
        public int Id { get; set; }
        public EmployeeDto Employees { get; set; }
        public List<EmpAbsenceDateDto> EmpWithAbsDates { get; set; }
        public List<EmpShiftRequiremetsDto> EmpWithShiftRequirements { get; set; }
    }
}
