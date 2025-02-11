using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.ViewModels
{
    public class TypeQuizVM
    {
        public TypeQuiz TypeQuiz { get; set; }

        public IEnumerable<SelectListItem> QuizList  { get; set; }
    }
}
