using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Interface;

namespace Quiz.Web.Controllers
{
    public class QuestionController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public QuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Create(int quizId) 
        {
            if (quizId == 0) 
            {
                return NotFound();
            }
            var quiz = _unitOfWork.Quiz.Get(u => u.Id == quizId, includeProperties: "TypeQuize,QuestionList,Event");
            if (quiz == null) 
            {
                return NotFound();
            }
            QuestionVM questionVM = new()
            {
                Question = new Question(),
                Answers = new List<Answer>(),
                Quiz = quiz

            };
            return View(questionVM);
        }

        [HttpPost]
        public IActionResult Create(QuestionVM questionVM, int quizId)
        {
            var quiz = _unitOfWork.Quiz.Get(u => u.Id == quizId, includeProperties: "TypeQuize,Event,QuestionList");

            if (quiz == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid) 
            {
                questionVM.Quiz = quiz;
                quiz?.QuestionList?.Add(questionVM.Question);
                _unitOfWork.Question.Add(questionVM.Question);
                _unitOfWork.Save();
                return View(questionVM);
            }

            questionVM.Answers = new List<Answer>();
            questionVM.Quiz = quiz;
            questionVM.Question = new Question();
            return View(questionVM);
        }
    }
}
