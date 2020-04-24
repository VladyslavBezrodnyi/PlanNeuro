using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanNeuro.DAL.Entities
{
    public class Board
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }


        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<UserBoard> UserBoards { get; set; }
        public virtual ICollection<CardsList> CardsLists { get; set; }

        public Board()
        {
            UserBoards = new HashSet<UserBoard>();
            CardsLists = new HashSet<CardsList>();
        }
    }
}
