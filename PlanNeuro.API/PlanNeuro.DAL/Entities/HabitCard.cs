using System;
using System.Collections.Generic;
using System.Text;

namespace PlanNeuro.DAL.Entities
{
    public class HabitCard : Card
    {
        public int DoneCounter { get; set; }
        public int NotDoneCounter { get; set; }
    }
}
