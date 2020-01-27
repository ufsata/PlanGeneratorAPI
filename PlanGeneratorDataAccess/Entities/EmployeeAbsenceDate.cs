using System;
using System.Collections.Generic;
using System.Text;

namespace PlanGeneratorDataAccess.Entities
{
    public class EmployeeAbsenceDate
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
