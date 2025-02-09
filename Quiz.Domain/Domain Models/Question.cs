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


        [Display(Name ="Прашање")]
        public string? Text { get; set; }

        public ICollection<Answer>? Answers { get; set; }

        [ForeignKey("QuizId")]
        public Quiz? Quiz { get; set; }

       
        public int QuizId { get; set; }
    }
}
