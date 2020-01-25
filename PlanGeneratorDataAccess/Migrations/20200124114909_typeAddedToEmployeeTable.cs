using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanGeneratorDataAccess.Migrations
{
    public partial class typeAddedToEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstShiftEndtDate",
                table: "EmployeeShiftRequrements");

            migrationBuilder.DropColumn(
                name: "ThirdShiftEndtDate",
                table: "EmployeeShiftRequrements");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstShiftEndDate",
                table: "EmployeeShiftRequrements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ThirdShiftEndDate",
                table: "EmployeeShiftRequrements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstShiftEndDate",
                table: "EmployeeShiftRequrements");

            migrationBuilder.DropColumn(
                name: "ThirdShiftEndDate",
                table: "EmployeeShiftRequrements");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Employees");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstShiftEndtDate",
                table: "EmployeeShiftRequrements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ThirdShiftEndtDate",
                table: "EmployeeShiftRequrements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
