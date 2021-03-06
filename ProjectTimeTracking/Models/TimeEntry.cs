﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required(ErrorMessage ="When was this work done?")]
        [Description("Date Worked")]
        [Display(Name = "Date Worked")]
        public DateTime DateWorked { get; set; }
        [Required(ErrorMessage ="Please enter the amount of time spent on this project during this work session.")]
        [Description("Time Worked")]
        [Display(Name = "Time Worked")]
        public double TimeWorked { get; set; }
        //[Required(ErrorMessage ="What project was this for?")]
        public Project Project{ get; set; }
        //[Required(ErrorMessage ="Who completed this work?")]
        public Employee Employee { get; set; }
    }
}
