using System.Collections.Generic;

namespace PlanNeuro.Domain.DTOs
{
    public class CardsListDTO
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<CardDTO> Cards { get; set; }
    }
}
