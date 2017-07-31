using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimeTracking.Models
{
    public enum EmploymentType
    {
        FullTime,
        PartTime,
        Contract,
        Intern
    }
    public class Employee
    {
        public int ID { get; set; }

        public string EmployeeFirstMidName { get; set; }

        public string EmployeeLastName { get; set; }

        public EmploymentType KindOfEmployment{ get; set; }

        public  string  EmployeeUserName { get; set; }

        public string EmployeePassword { get; set; }
       
        public ICollection<TimeEntry> TimeEntries { get; set; }
    }
}