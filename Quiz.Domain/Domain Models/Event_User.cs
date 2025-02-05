using Quiz.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Domain_Models
{
    public class Event_User
    {
        public Event? Event { get; set; }

        public int EventId { get; set; }

        public ApplicationUser? User { get; set; }

        public int UserId { get; set; }
    }
}
