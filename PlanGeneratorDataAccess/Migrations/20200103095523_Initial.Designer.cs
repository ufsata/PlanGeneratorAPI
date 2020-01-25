﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanGeneratorDataAccess;

namespace PlanGeneratorDataAccess.Migrations
{
    [DbContext(typeof(PlanGeneratorContext))]
    [Migration("20200103095523_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlanGeneratorDataAccess.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PlanGeneratorDataAccess.Entities.EmployeeAbsenceDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeAbsenceDates");
                });

            modelBuilder.Entity("PlanGeneratorDataAccess.Entities.EmployeeShiftRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FirstShiftEndtDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FirstShiftStartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SecondShiftEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SecondShiftStartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThirdShiftEndtDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThirdShiftStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeShiftRequrements");
                });

            modelBuilder.Entity("PlanGeneratorDataAccess.Entities.EmployeeAbsenceDate", b =>
                {
                    b.HasOne("PlanGeneratorDataAccess.Entities.Employee", "Employee")
                        .WithMany("EmployeeAbsenceDates")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlanGeneratorDataAccess.Entities.EmployeeShiftRequirement", b =>
                {
                    b.HasOne("PlanGeneratorDataAccess.Entities.Employee", "Employee")
                        .WithMany("EmployeeShiftRequrements")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
