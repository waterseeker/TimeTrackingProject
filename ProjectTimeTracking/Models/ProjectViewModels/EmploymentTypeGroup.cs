using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTimeTracking.Models.ProjectViewModels
{
    public class EmploymentTypeGroup
    {

        [EnumDataType(typeof(EmploymentType))]
        public EmploymentType KindOfEmployment { get; set; }

        public int EmployeeCount { get; set; }
    }
}
