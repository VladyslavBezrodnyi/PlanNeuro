using System;
using System.ComponentModel.DataAnnotations;

namespace PlanNeuro.DAL.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Discriminator { get; set; }
        public int? ItemNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public int? Duration { get; set; }
        public int? Complexity { get; set; }

        public int CardsListId { get; set; }
        public virtual CardsList CardsList { get; set; }
    }
}