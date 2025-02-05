using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Domain_Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }


        public string? Text { get; set; }

        public ICollection<Answer>? Answers { get; set; }

        public Quize? Quiz { get; set; }

        [ForeignKey("QuizId")]
        public int QuizId { get; set; }
    }
}
