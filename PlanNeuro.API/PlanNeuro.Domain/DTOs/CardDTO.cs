using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanNeuro.Domain.DTOs
{
    public class CardDTO
    {
        [Required]
        public int Id { get; set; }
        public int? BoardId { get; set; }
        public int CardsListId { get; set; }
        public string Discriminator { get; set; }
        public int? ItemNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public int? Duration { get; set; }
        [Required]
        [Range(0,10)]
        public int? Complexity { get; set; }
    }

    public class HabitCardDTO : CardDTO
    {
        public int DoneCounter { get; set; }
        public int NotDoneCounter { get; set; }
    }

    public class PlanCardDTO : CardDTO
    {
        public bool IsDone { get; set; }
        public int? DoneUserId { get; set; }
        public UserDTO DoneUser { get; set; }
    }
}
