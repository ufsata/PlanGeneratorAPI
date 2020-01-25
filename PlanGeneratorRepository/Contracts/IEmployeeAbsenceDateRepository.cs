using PlanGeneratorDataAccess.Entities;
using PlanGeneratorDto.EmployeeAbsenceDate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanGeneratorRepository.Contracts
{
    public interface IEmployeeAbsenceDateRepository
    {
        Task<List<EmpAbsenceDateDto>> GetListOfEmpAbsenceDates();
        Task<List<EmpAbsenceDateDto>> GetEmpAbsenceDatesById(int id);
        Task<EmployeeAbsenceDate> AddEmpAbsenceDate(EmpAbsenceDateDto empAbsDate);
        Task<EmployeeAbsenceDate> UpdateEmpAbsenceDate(EmpAbsenceDateDto empAbsDate);
        Task<EmployeeAbsenceDate> DeleteEmpAbsenceDate(int id);
    }
}
