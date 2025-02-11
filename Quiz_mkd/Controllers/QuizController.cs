using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Domain.Domain_Models;
namespace Quiz.Web.Controllers
{
    public class QuizController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuizController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var items = _unitOfWork.Quiz.GetAll(includeProperties: "TypeQuize,QuestionList,Event");
            return View(items);
        }

        public IActionResult Create() 
        {
            QuizVM quizVM = new()
            {
                Quiz = new Domain.Domain_Models.Quiz(),
                TypeQuizList = _unitOfWork.TypeQuiz.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Type,
                    Value = u.Id.ToString()
                }),
                EventList = _unitOfWork.Event.GetAll(includeProperties: "Quiz").Where(u => u.Quiz == null)
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                QuestionList = new List<Question>()
            };
            return View(quizVM);
            
        }

        [HttpPost]
        public IActionResult Create(QuizVM quizVM)
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.Quiz.Add(quizVM.Quiz);
                _unitOfWork.Save();
                quizVM.TypeQuizList = _unitOfWork.TypeQuiz.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Type,
                    Value = u.Id.ToString()
                });
                quizVM.EventList = _unitOfWork.Event.GetAll(includeProperties: "Quiz").Where(u => u.Quiz == null)
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                quizVM.QuestionList = new List<Question>();
                return View(quizVM);

            }

            QuizVM vm = new()
            {
                Quiz = new Domain.Domain_Models.Quiz(),
                TypeQuizList = _unitOfWork.TypeQuiz.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Type,
                    Value = u.Id.ToString()
                }),
                EventList = _unitOfWork.Event.GetAll(includeProperties: "Quiz").Where(u => u.Quiz == null)
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                QuestionList = new List<Question>()
            };
            return View(vm);

        }

        public IActionResult Delete(int? id) 
        {
            var quiz = _unitOfWork.Quiz.Get(u => u.Id == id, includeProperties: "TypeQuize,Event");
            
            return View(quiz);
        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeleteDB(int? id)
        {
            if (id == 0 && id == null) 
            {
                return NotFound();
            }
            var quiz = _unitOfWork.Quiz.Get(u => u.Id == id, includeProperties: "TypeQuize,Event");

            if (quiz == null) 
            {
                return NotFound();
            }

            _unitOfWork.Quiz.Remove(quiz);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Quiz");
        }

    }
}
