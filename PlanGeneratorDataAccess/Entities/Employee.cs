using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string UserId { get; set; }
    }
}
