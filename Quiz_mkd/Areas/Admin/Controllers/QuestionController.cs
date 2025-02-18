using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Interface;

namespace Quiz.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = _unitOfWork.Question.Get(u => u.Id == id, includeProperties: "Answers,Quiz");
            if (item == null)
            {
                return NotFound();
            }
            QuestionVM questionVM = new()
            {
                Question = item,
                Answers = item.Answers,
                Quiz = item.Quiz
            };
            return View(questionVM);
        }

        [HttpPost]
        public IActionResult Edit(QuestionVM questionVm)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Question.Update(questionVm.Question);
                _unitOfWork.Save();
                return RedirectToAction("Detail", "Quiz", new { quizId = questionVm.Question.QuizId});
            }

            return View(questionVm);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = _unitOfWork.Question.Get(u => u.Id == id, includeProperties: "Answers,Quiz");
            if (item == null)
            {
                return NotFound();
            }
            QuestionVM questionVM = new()
            {
                Question = item,
                Answers = item.Answers,
                Quiz = item.Quiz
            };
            return View(questionVM);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteDB(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var question = _unitOfWork.Question.Get(u => u.Id == id, includeProperties: "Answers,Quiz");
            if (question == null)
            {
                return NotFound();
            }
            _unitOfWork.Question.Remove(question);
            _unitOfWork.Save();
            return RedirectToAction("Detail", "Quiz", new { quizId = question.QuizId });



        }


    }
}
