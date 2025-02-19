using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Domain.Domain_Models;


namespace Quiz.Domain.ViewModels
{
    public class TypeQuizVM
    {
        public TypeQuiz TypeQuiz { get; set; }

        public IEnumerable<SelectListItem> QuizList  { get; set; }
    }
}
