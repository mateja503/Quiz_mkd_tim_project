using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Domain_Models
{
    public class  TypeQuiz
    {
        [Key]
        public int Id { get; set; }

        public string? Type { get; set; }

        public ICollection<Quiz?> QuizList { get; set; }
    }
}
