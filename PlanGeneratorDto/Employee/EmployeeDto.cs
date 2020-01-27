using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanGeneratorDto.Employee
{
    public class EmployeeDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
