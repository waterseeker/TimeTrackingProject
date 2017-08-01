using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimeTracking.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectID { get; set; }
        [StringLength(50, ErrorMessage = "Project name cannot be longer than 50 characters.")]
        public string ProjectName { get; set; }
        [StringLength(250, ErrorMessage = "Project description cannot be longer than 250 characters.")]
        public string ProjectDescription { get; set; }
        public decimal CompletionTimeEstimate { get; set; }
        public ICollection<TimeEntry> TimeEntries { get; set; }
    }
}
