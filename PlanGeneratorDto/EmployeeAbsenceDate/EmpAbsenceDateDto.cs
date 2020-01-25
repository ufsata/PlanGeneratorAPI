using System;
using System.Collections.Generic;
using System.Text;

namespace PlanGeneratorDto.EmployeeAbsenceDate
{
    public class EmpAbsenceDateDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmpId { get; set; }
    }
}
