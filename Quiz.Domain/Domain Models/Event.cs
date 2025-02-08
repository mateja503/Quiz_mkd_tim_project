using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Domain_Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }


        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<Event_User>? Event_User { get; set; }

        public Quiz? Quiz { get; set; }


    }
}
