using System;
using System.Collections.Generic;
using System.Text;

namespace PlanNeuro.Domain.DTOs
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public int Rating { get; set; }
    }
}
