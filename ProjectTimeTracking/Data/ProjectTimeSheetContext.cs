using ProjectTimeTracking.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectTimeTracking.Data
{
    public class ProjectTimeTrackingContext : DbContext
    {
        public ProjectTimeTrackingContext(DbContextOptions<ProjectTimeTrackingContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<TimeEntry>().ToTable("TimeEntry");
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }
    }
}
