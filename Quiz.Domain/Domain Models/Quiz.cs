using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Domain_Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TypeQuizeId")]
        public TypeQuiz? TypeQuize { get; set; }

        public int TypeQuizeId { get; set; }

        [Display(Name = "Questions")]
        public ICollection<Question>? QuestionList { get; set; }

        [ForeignKey("EventId")]
        public Event? Event { get; set; }

        public int? EventId { get; set; }
    }
}
