using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanNeuro.Domain.ModelValidators
{
    public class ValidationResults
    {
        public List<ValidationResult> ValidationResultsMessages { get; set; }
        public bool Successed { get; set; }
    }
}
