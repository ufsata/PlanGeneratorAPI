using Microsoft.EntityFrameworkCore;
using PlanGeneratorDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanGeneratorDataAccess
{
    public class PlanGeneratorContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAbsenceDate> EmployeeAbsenceDates { get; set; }
        public DbSet<EmployeeShiftRequirement> EmployeeShiftRequrements { get; set; }

        public PlanGeneratorContext()
        {
        }

        public PlanGeneratorContext(DbContextOptions<PlanGeneratorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=PlanGeneratorApiDB;Integrated Security=true;");
            }
        }
    }
}
