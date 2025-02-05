using Quiz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Domain_Models
{
    public class Quize
    {
        [Key]
        public int id { get; set; }

        

        public TypeQuizes TypeQuizes { get; set; }

        [Display(Name = "Questions")]
        ICollection<Question>? Question { get; set; }
    }
}
