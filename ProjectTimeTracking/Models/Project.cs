using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimeTracking.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        [StringLength(50, ErrorMessage = "Project name cannot be longer than 50 characters.")]
        [Required(ErrorMessage = "Please enter a name for the project.")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [StringLength(250, ErrorMessage = "Project description cannot be longer than 250 characters.")]
        [Required(ErrorMessage ="Please enter a short description of the project.")]
        [Description("Project Description")]
        [Display(Name = "Project Description")]
        public string ProjectDescription { get; set; }
        [Description("Completion Time Estimate")]
        [Display(Name = "Completion Time Estimate")]
        public double CompletionTimeEstimate { get; set; }
        public ICollection<TimeEntry> TimeEntries { get; set; }
    }
}
