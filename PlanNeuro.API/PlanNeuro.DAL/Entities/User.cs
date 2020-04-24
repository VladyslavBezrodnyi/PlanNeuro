using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PlanNeuro.DAL.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }

        public virtual ICollection<UserBoard> UserBoards { get; set; }
        public virtual ICollection<PlanCard> DoneCards { get; set; }
        public virtual Board PersonalBoard { get; set; }

        public User()
        {
            UserBoards = new HashSet<UserBoard>();
            DoneCards = new HashSet<PlanCard>();
        }
    }
}
