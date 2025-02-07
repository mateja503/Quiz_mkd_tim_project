using Microsoft.AspNetCore.Identity;
using Quiz.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {

        [Required]

        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        public double Points { get; set; }
        public string? ImageUrl { get; set; }
        ICollection<Event_User>? Event_User { get; set; }
    }
}
