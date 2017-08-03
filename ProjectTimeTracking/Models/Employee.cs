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
        public int EmployeeID { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z''-'\s]*$")]
        [Required(ErrorMessage ="Please enter a last name.")]
        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }
        [EnumDataType(typeof(EmploymentType))]
        [Required(ErrorMessage = "Please choose an employment type.")]
        [Display(Name = "Employment Type")]
        public EmploymentType KindOfEmployment{ get; set; }

        public  string  EmployeeUserName { get; set; }

        public string EmployeePassword { get; set; }
        public string FullName
        {
            get
            {
                return EmployeeFirstName + " " + EmployeeLastName;
            }
        }

        public ICollection<TimeEntry> TimeEntries { get; set; }

    }

    public enum EmploymentType
    {
        [Description("Full Time")]
        [Display(Name = "Full Time")]
        FullTime,
        [Description("Part Time")]
        [Display(Name = "Part Time")]
        PartTime,
        [Description("Contract")]
        [Display(Name = "Contract")]
        Contract,
        [Description("Intern")]
        Intern
    }
}