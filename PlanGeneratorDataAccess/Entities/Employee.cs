using System;
using System.Collections.Generic;
using System.Text;

namespace PlanGeneratorDataAccess.Entities
{
    public class Employee
    {
        //Foreign key for EmployeeAbsenceDates and for EmployeeShiftRequrements
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public ICollection<EmployeeAbsenceDate> EmployeeAbsenceDates { get; set; }
        public ICollection<EmployeeShiftRequirement> EmployeeShiftRequrements { get; set; }
    }
}
