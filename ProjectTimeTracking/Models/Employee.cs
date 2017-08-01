using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;


namespace ProjectTimeTracking.Models
{


    public class Employee
    {
        public int ID { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }
        [EnumDataType(typeof(EmploymentType))]
        public EmploymentType KindOfEmployment{ get; set; }

        public  string  EmployeeUserName { get; set; }

        public string EmployeePassword { get; set; }
       
        public ICollection<TimeEntry> TimeEntries { get; set; }
    }

    public enum EmploymentType
    {
        [Display(Name = "FullTime")]
        FullTime,
        [Description("Part Time")]
        PartTime,
        [Description("Contract")]
        Contract,
        [Description("Intern")]
        Intern
    }
}