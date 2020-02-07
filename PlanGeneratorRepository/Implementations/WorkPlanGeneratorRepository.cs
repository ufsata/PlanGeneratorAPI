using Microsoft.EntityFrameworkCore;
using PlanGeneratorDataAccess;
using PlanGeneratorDto.Employee;
using PlanGeneratorDto.EmployeeAbsenceDate;
using PlanGeneratorDto.EmployeeShiftRequirements;
using PlanGeneratorDto.WorkPlan;
using PlanGeneratorRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanGeneratorRepository.Implementations
{
    public class WorkPlanGeneratorRepository : IWorkPlanGeneratorRepository
    {
        private readonly PlanGeneratorContext _context;

        public WorkPlanGeneratorRepository(PlanGeneratorContext context)
        {
            _context = context;
        }
        //TODO
        public async Task<WorkPlanDto> GenerateWorkPlan(DateTime startDate, DateTime endDate)
        {            
            var empWithAbsDates = await GetListOfEmpAbsenceDatesByDate(startDate, endDate);
            var empWithShiftRequirements = await GetListOfEmpShiftRequirementsByDate(startDate, endDate);
            //TODO
            int empPerShift = 2;

            var workPlanDto = new WorkPlanDto()
            {

            };
            throw new NotImplementedException();
        }
        
        public async Task<List<EmpAbsenceDateDto>> GetListOfEmpAbsenceDatesByDate(DateTime StartDate, DateTime endDate)
        {
            return await _context.EmployeeAbsenceDates.Where(e => (e.StartDate >= StartDate && e.StartDate <= endDate) || 
                                                                    (e.EndDate >= StartDate && e.EndDate <= endDate))
                                                                    .Select(e => new EmpAbsenceDateDto
                                                                    {
                                                                        Id = e.Id,
                                                                        StartDate = e.StartDate,
                                                                        EndDate = e.EndDate,
                                                                        EmpId = e.EmployeeId,
                                                                        Type = e.Type
                                                                    }).ToListAsync();
        }

        public async Task<List<EmpShiftRequiremetsDto>> GetListOfEmpShiftRequirementsByDate(DateTime StartDate, DateTime endDate)
        {
            return await _context.EmployeeShiftRequrements.Where(e => e.FirstShiftStartDate >= StartDate && e.FirstShiftStartDate <= endDate ||
                                                                      e.SecondShiftStartDate >= StartDate && e.SecondShiftStartDate <= endDate || 
                                                                      e.ThirdShiftStartDate >= StartDate && e.ThirdShiftStartDate <= endDate ||
                                                                      e.FirstShiftEndDate >= StartDate && e.FirstShiftEndDate <= endDate ||
                                                                      e.SecondShiftEndDate >= StartDate && e.SecondShiftEndDate <= endDate ||
                                                                      e.ThirdShiftEndDate >= StartDate && e.ThirdShiftEndDate <= endDate)
                                                                      .Select(e => new EmpShiftRequiremetsDto
                                                                      {
                                                                          Id = e.Id,
                                                                          EmpId = e.EmployeeId,
                                                                          FirstShiftStartDate = e.FirstShiftStartDate,
                                                                          FirstShiftEndDate = e.FirstShiftEndDate,
                                                                          SecondShiftStartDate = e.SecondShiftStartDate,
                                                                          SecondShiftEndDate = e.SecondShiftEndDate,
                                                                          ThirdShiftStartDate = e.ThirdShiftStartDate,
                                                                          ThirdShiftEndDate = e.ThirdShiftEndDate
                                                                      }).ToListAsync();
        }


    }
}
