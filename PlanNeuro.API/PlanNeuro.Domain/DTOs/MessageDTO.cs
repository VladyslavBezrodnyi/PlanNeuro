using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanNeuro.Domain.DTOs
{
    public class MessageDTO
    {
        [Required]
        public int BoardId { get; set; }
        [Required]
        public int UserId { get; set; }

        public string Text { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
