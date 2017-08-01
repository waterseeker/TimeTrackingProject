using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimeTracking.Models
{
    public class TimeEntry
    {
        public int TimeEntryID { get; set; }
        public int ProjectID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime DateWorked { get; set; }
        public double TimeWorked { get; set; }
        public Project Project { get; set; }
        public Employee Employee { get; set; }
    }
}
