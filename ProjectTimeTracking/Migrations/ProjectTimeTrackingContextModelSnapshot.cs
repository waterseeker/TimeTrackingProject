using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectTimeTracking.Data;
using ProjectTimeTracking.Models;

namespace ProjectTimeTracking.Migrations
{
    [DbContext(typeof(ProjectTimeTrackingContext))]
    partial class ProjectTimeTrackingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectTimeTracking.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeFirstName")
                        .HasMaxLength(50);

                    b.Property<string>("EmployeeLastName")
                        .HasMaxLength(50);

                    b.Property<string>("EmployeePassword");

                    b.Property<string>("EmployeeUserName");

                    b.Property<int>("KindOfEmployment");

                    b.HasKey("ID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ProjectTimeTracking.Models.Project", b =>
                {
                    b.Property<int>("ProjectID");

                    b.Property<decimal>("CompletionTimeEstimate");

                    b.Property<string>("ProjectDescription")
                        .HasMaxLength(250);

                    b.Property<string>("ProjectName")
                        .HasMaxLength(50);

                    b.HasKey("ProjectID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("ProjectTimeTracking.Models.TimeEntry", b =>
                {
                    b.Property<int>("TimeEntryID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateWorked");

                    b.Property<int>("EmployeeID");

                    b.Property<int>("ProjectID");

                    b.Property<double>("TimeWorked");

                    b.HasKey("TimeEntryID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ProjectID");

                    b.ToTable("TimeEntry");
                });

            modelBuilder.Entity("ProjectTimeTracking.Models.TimeEntry", b =>
                {
                    b.HasOne("ProjectTimeTracking.Models.Employee", "Employee")
                        .WithMany("TimeEntries")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectTimeTracking.Models.Project", "Project")
                        .WithMany("TimeEntries")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
