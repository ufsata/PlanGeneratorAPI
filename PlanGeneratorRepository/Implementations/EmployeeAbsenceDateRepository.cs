using Microsoft.EntityFrameworkCore;
using PlanGeneratorDataAccess;
using PlanGeneratorDataAccess.Entities;
using PlanGeneratorDto.EmployeeAbsenceDate;
using PlanGeneratorRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanGeneratorRepository.Implementations
{
    public class EmployeeAbsenceDateRepository : IEmployeeAbsenceDateRepository
    {
        private readonly PlanGeneratorContext _context;

        public EmployeeAbsenceDateRepository(PlanGeneratorContext context)
        {
            _context = context;
        }

        public async Task<EmployeeAbsenceDate> AddEmpAbsenceDate(EmpAbsenceDateDto empAbsDate)
        {
            var newAbsenceDate = new EmployeeAbsenceDate
            {
                Id = empAbsDate.Id,
                StartDate = empAbsDate.StartDate,
                EndDate = empAbsDate.EndDate,
                EmployeeId = empAbsDate.EmpId,
                Type = empAbsDate.Type
            };

            _context.EmployeeAbsenceDates.Add(newAbsenceDate);
            await _context.SaveChangesAsync();

            return newAbsenceDate;
        }

        public async Task<EmployeeAbsenceDate> DeleteEmpAbsenceDate(int id)
        {
            var absDateForDelete = await _context.EmployeeAbsenceDates.FirstOrDefaultAsync(e => e.Id == id) ??
                   throw new Exception("No such Absence Date");

            _context.Set<EmployeeAbsenceDate>().Remove(absDateForDelete);
            await _context.SaveChangesAsync();

            return absDateForDelete;
        }

        public async Task<List<EmpAbsenceDateDto>> GetEmpAbsenceDatesById(int id)
        {
            return await _context.EmployeeAbsenceDates.Where(e => e.EmployeeId == id).Select(e => new EmpAbsenceDateDto
            {
                Id = e.Id,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                EmpId = e.EmployeeId,
                Type = e.Type
            }).ToListAsync();
        }

        public async Task<List<EmpAbsenceDateDto>> GetListOfEmpAbsenceDates()
        {
            return await _context.EmployeeAbsenceDates.Select(e => new EmpAbsenceDateDto
            {
                Id = e.Id,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                EmpId = e.EmployeeId,
                Type = e.Type
            }).ToListAsync();
        }
        
        public async Task<EmployeeAbsenceDate> UpdateEmpAbsenceDate(EmpAbsenceDateDto empAbsDate)
        {
            var absenceDateForUpdate = new EmployeeAbsenceDate
            {
                Id = empAbsDate.Id,
                StartDate = empAbsDate.StartDate,
                EndDate = empAbsDate.EndDate,
                EmployeeId = empAbsDate.EmpId,
                Type = empAbsDate.Type
            };

            _context.EmployeeAbsenceDates.Update(absenceDateForUpdate);
            await _context.SaveChangesAsync();

            return absenceDateForUpdate;
        }
    }
}
