using System;
using System.Collections.Generic;
using System.Text;

namespace PlanGeneratorDto.EmployeeShiftRequirements
{
    public class EmpShiftRequiremetsDto
    {
        public int Id { get; set; }
        public DateTime FirstShiftStartDate { get; set; }
        public DateTime FirstShiftEndDate { get; set; }

        public DateTime SecondShiftStartDate { get; set; }
        public DateTime SecondShiftEndDate { get; set; }

        public DateTime ThirdShiftStartDate { get; set; }
        public DateTime ThirdShiftEndDate { get; set; }


        public int EmpId { get; set; }
    }
}
