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

        [HttpPost]
        public IActionResult Create(int id) 
        {
            if (id == 0) 
            {
                return NotFound();
            }
            var quiz = _unitOfWork.Quiz.Get(u => u.Id == id, includeProperties: "TypeQuize,QuestionList,Event");
            QuestionVM questionVM = new()
            {
                Question = new Question(),
                Answers = new List<Answer>(),
                Quiz = quiz

            };
            return View(questionVM);
        }
    }
}
