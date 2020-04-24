using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanNeuro.Domain.DTOs
{
    public class BoardDTO
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public ICollection<CardsListDTO> CardsLists { get; set; }
        public ICollection<UserDTO> Participants { get; set; }
    }
}
