using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimeTracking.Models
{
    public class TimeEntry
    {
        public int TimeEntryID { get; set; }
        public int ProjectID { get; set; }
        public int EmployeeID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateWorked { get; set; }
        public double TimeWorked { get; set; }
        public Project Project{ get; set; }
        public Employee Employee { get; set; }
    }
}
