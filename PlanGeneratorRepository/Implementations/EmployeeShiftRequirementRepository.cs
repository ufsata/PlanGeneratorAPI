using Microsoft.EntityFrameworkCore;
using PlanGeneratorDataAccess;
using PlanGeneratorDataAccess.Entities;
using PlanGeneratorDto.EmployeeShiftRequirements;
using PlanGeneratorRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanGeneratorRepository.Implementations
{
    public class EmployeeShiftRequirementRepository : IEmployeeShiftRequirementRepository
    {
        private readonly PlanGeneratorContext _context;

        public EmployeeShiftRequirementRepository(PlanGeneratorContext context)
        {
            _context = context;
        }
        public async Task<EmployeeShiftRequirement> AddEmpShiftRequirements(EmpShiftRequiremetsDto empShiftRequirement)
        {
            var newShiftRequirement = new EmployeeShiftRequirement
            {
                Id = empShiftRequirement.Id,
                FirstShiftStartDate = empShiftRequirement.FirstShiftStartDate,
                FirstShiftEndDate = empShiftRequirement.FirstShiftEndDate,
                SecondShiftStartDate = empShiftRequirement.SecondShiftStartDate,
                SecondShiftEndDate = empShiftRequirement.SecondShiftEndDate,
                ThirdShiftStartDate = empShiftRequirement.ThirdShiftStartDate,
                ThirdShiftEndDate = empShiftRequirement.ThirdShiftEndDate,
                EmployeeId = empShiftRequirement.EmpId
            };

            _context.EmployeeShiftRequrements.Add(newShiftRequirement);
            await _context.SaveChangesAsync();

            return newShiftRequirement;
        }

        public async Task<EmployeeShiftRequirement> DeleteEmpShiftRequirements(int id)
        {
            var shiftReuirementForDelete = await _context.EmployeeShiftRequrements.FirstOrDefaultAsync(e => e.Id == id) ??
                throw new Exception("No such Absence Date");

            _context.Set<EmployeeShiftRequirement>().Remove(shiftReuirementForDelete);
            await _context.SaveChangesAsync();

            return shiftReuirementForDelete;
        }

        public async Task<List<EmpShiftRequiremetsDto>> GetEmpShiftRequirementsById(int id)
        {
            return await _context.EmployeeShiftRequrements.Where(e => e.EmployeeId == id).Select(e => new EmpShiftRequiremetsDto
            {
                Id = e.Id,
                FirstShiftStartDate = e.FirstShiftStartDate,
                FirstShiftEndDate = e.FirstShiftEndDate,
                SecondShiftStartDate = e.SecondShiftStartDate,
                SecondShiftEndDate = e.SecondShiftEndDate,
                ThirdShiftStartDate = e.ThirdShiftStartDate,
                ThirdShiftEndDate = e.ThirdShiftEndDate,
                EmpId = e.EmployeeId
            }).ToListAsync();
        }

        public async Task<List<EmpShiftRequiremetsDto>> GetListOfEmpShiftRequirements()
        {
            return await _context.EmployeeShiftRequrements.Select(e => new EmpShiftRequiremetsDto
            {
                Id = e.Id,
                FirstShiftStartDate = e.FirstShiftStartDate,
                FirstShiftEndDate = e.FirstShiftEndDate,
                SecondShiftStartDate = e.SecondShiftStartDate,
                SecondShiftEndDate = e.SecondShiftEndDate,
                ThirdShiftStartDate = e.ThirdShiftStartDate,
                ThirdShiftEndDate = e.ThirdShiftEndDate,
                EmpId = e.EmployeeId
            }).ToListAsync();
        }

        public async Task<EmployeeShiftRequirement> UpdateEmpShiftRequirements(EmpShiftRequiremetsDto empShiftRequirement)
        {
            var shiftRequirementForUpdate = new EmployeeShiftRequirement
            {
                Id = empShiftRequirement.Id,
                FirstShiftStartDate = empShiftRequirement.FirstShiftStartDate,
                FirstShiftEndDate = empShiftRequirement.FirstShiftEndDate,
                SecondShiftStartDate = empShiftRequirement.SecondShiftStartDate,
                SecondShiftEndDate = empShiftRequirement.SecondShiftEndDate,
                ThirdShiftStartDate = empShiftRequirement.ThirdShiftStartDate,
                ThirdShiftEndDate = empShiftRequirement.ThirdShiftEndDate,
                EmployeeId = empShiftRequirement.EmpId
            };

            _context.EmployeeShiftRequrements.Update(shiftRequirementForUpdate);
            await _context.SaveChangesAsync();

            return shiftRequirementForUpdate;
        }
    }
}
