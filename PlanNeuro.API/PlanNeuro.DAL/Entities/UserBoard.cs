using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanNeuro.DAL.Entities
{
    public class UserBoard
    {
        [Key]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Key]
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }

        public virtual ICollection<ConversationReply> ConversationReplies { get; set; }

        public UserBoard()
        {
            ConversationReplies = new HashSet<ConversationReply>();
        }
    }
}
