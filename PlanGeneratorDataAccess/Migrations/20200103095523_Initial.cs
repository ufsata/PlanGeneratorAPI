using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanGeneratorDataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAbsenceDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAbsenceDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAbsenceDates_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShiftRequrements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstShiftStartDate = table.Column<DateTime>(nullable: false),
                    FirstShiftEndtDate = table.Column<DateTime>(nullable: false),
                    SecondShiftStartDate = table.Column<DateTime>(nullable: false),
                    SecondShiftEndDate = table.Column<DateTime>(nullable: false),
                    ThirdShiftStartDate = table.Column<DateTime>(nullable: false),
                    ThirdShiftEndtDate = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShiftRequrements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeShiftRequrements_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAbsenceDates_EmployeeId",
                table: "EmployeeAbsenceDates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShiftRequrements_EmployeeId",
                table: "EmployeeShiftRequrements",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAbsenceDates");

            migrationBuilder.DropTable(
                name: "EmployeeShiftRequrements");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
