using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanGeneratorDataAccess.Migrations
{
    public partial class typeAddedToEmployeeAbsenceDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "EmployeeAbsenceDates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "EmployeeAbsenceDates");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
