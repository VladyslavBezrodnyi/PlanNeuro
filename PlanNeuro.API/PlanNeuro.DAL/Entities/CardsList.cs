using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanNeuro.DAL.Entities
{
    public class CardsList
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }
        public virtual ICollection<Card> Cards { get; set; }

        public CardsList()
        {
            Cards = new HashSet<Card>();
        }
    }
}