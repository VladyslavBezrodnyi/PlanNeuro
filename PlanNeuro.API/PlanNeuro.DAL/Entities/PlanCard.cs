using System;
using System.Collections.Generic;
using System.Text;

namespace PlanNeuro.DAL.Entities
{
    public class PlanCard : Card
    {
        public bool IsDone { get; set; }

        public int? DoneUserId { get; set; }
        public User DoneUser { get; set; }
    }
}
