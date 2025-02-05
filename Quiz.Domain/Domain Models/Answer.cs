using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Domain_Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

       
        public Question? Question { get; set; }

        [ForeignKey("QuestionId")]
        public int QuestionId { get; set; }

        public string? Text { get; set; }

        public bool Correct { get; set; }
    }
}
