using Quiz.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Identity
{
    public class ApplicationUser 
    {

        public string? UserName { get; set; }
        public double Points { get; set; }
        public string? ImageUrl { get; set; }
        ICollection<Event_User>? Event_User { get; set; }
    }
}
