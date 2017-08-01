using ProjectTimeTracking.Data;
using ProjectTimeTracking.Models;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProjectTimeTrackingContext context)
        {
            context.Database.EnsureCreated();

            // Look for any employees.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
            new Employee{EmployeeFirstName="Carson",EmployeeLastName="Alexander",KindOfEmployment=[0]},
            new Employee{EmployeeFirstName="Meredith",EmployeeLastName="Alonso",KindOfEmployment=[1]},
            new Employee{EmployeeFirstName="Arturo",EmployeeLastName="Anand",KindOfEmployment=[2]},
            new Employee{EmployeeFirstName="Gytis",EmployeeLastName="Barzdukas",KindOfEmployment=[3]},
            new Employee{EmployeeFirstName="Yan",EmployeeLastName="Li",KindOfEmployment=[4]},
            new Employee{EmployeeFirstName="Peggy",EmployeeLastName="Justice",KindOfEmployment=[1]},
            new Employee{EmployeeFirstName="Laura",EmployeeLastName="Norman",KindOfEmployment=[2]},
            new Employee{EmployeeFirstName="Wayne",EmployeeLastName="Burris",KindOfEmployment=[3]}
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            var projects = new Project[]
            {
            new Project{ProjectID=1,ProjectName="ProjectTimeTracking",ProjectDescription="Making an app that can track time put in by employees on projects by employee and by project."},
            new Project{ProjectID=2,ProjectName="TeamMorale",ProjectDescription="The global initiative to improve team morale through chocolate."},
            new Project{ProjectID=3,ProjectName="HiringWayne",ProjectDescription="Hey, let's hire this guy!"},

            };
            foreach (Project p in projects)
            {
                context.Projects.Add(p);
            }
            context.SaveChanges();

            var timeEntries = new TimeEntry[]
            {
            new TimeEntry{EmployeeID=1,ProjectID=1,TimeWorked= 10.50, DateWorked= DateTime.Now},
            new TimeEntry{EmployeeID=2,ProjectID=3,TimeWorked= 11.50, DateWorked= DateTime.Now},
            new TimeEntry{EmployeeID=3,ProjectID=3,TimeWorked= 9.50, DateWorked= DateTime.Now},
            new TimeEntry{EmployeeID=4,ProjectID=3,TimeWorked= 10.50, DateWorked= DateTime.Now},
            new TimeEntry{EmployeeID=5,ProjectID=2,TimeWorked= 10.50, DateWorked= DateTime.Now},
            new TimeEntry{EmployeeID=6,ProjectID=3,TimeWorked= 8.50, DateWorked= DateTime.Now},
            new TimeEntry{EmployeeID=1,ProjectID=1,TimeWorked= 10.50, DateWorked= DateTime.Now},
            new TimeEntry{EmployeeID=2,ProjectID=3,TimeWorked= 9.50, DateWorked= DateTime.Now},
            new TimeEntry{EmployeeID=3,ProjectID=2,TimeWorked= 8.50, DateWorked= DateTime.Now},
            new TimeEntry{EmployeeID=4,ProjectID=3,TimeWorked= 10.75, DateWorked= DateTime.Now},
            new TimeEntry{EmployeeID=5,ProjectID=3,TimeWorked= 10.50, DateWorked= DateTime.Now},
            new TimeEntry{EmployeeID=6,ProjectID=3,TimeWorked= 8.50, DateWorked= DateTime.Now},
            };
            foreach (TimeEntry t in timeEntries)
            {
                context.TimeEntries.Add(t);
            }
            context.SaveChanges();
        }
    }
}
