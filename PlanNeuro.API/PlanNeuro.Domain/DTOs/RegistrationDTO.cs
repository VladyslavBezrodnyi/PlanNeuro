using PlanNeuro.Domain.ModelValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanNeuro.Domain.DTOs
{
    public class RegistrationDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailValidator]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
