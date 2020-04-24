using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanNeuro.DAL.Entities
{
    public class ConversationReply
    {
        [Key]
        public int Id { get; set; }

        public int BoardId { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; }

        public DateTimeOffset Date { get; set; }

        [ForeignKey("BoardId, UserId")]
        public virtual UserBoard Participant { get; set; }
    }
}