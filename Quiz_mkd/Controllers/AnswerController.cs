using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Interface;

namespace Quiz.Web.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnswerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var items = _unitOfWork.Answer.GetAll(includeProperties:"Question");

            return View(items);
        }

        public IActionResult Create(int questionId)
        {
            var question = _unitOfWork.Question.Get(u => u.Id == questionId, includeProperties: "Quiz,Answers");
            AnswerVM answerVM = new()
            {
                Answer = new Answer(),
                Question = question,
            };
            return View(answerVM);
        }

        [HttpPost]
        public IActionResult Create(AnswerVM answerVM, int questionId)
        {
            var question = _unitOfWork.Question.Get(u => u.Id == questionId, includeProperties: "Quiz,Answers");

            if (question == null) 
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                answerVM.Question = question;
                question?.Answers?.Add(answerVM.Answer);
                _unitOfWork.Answer.Add(answerVM.Answer);
                _unitOfWork.Save();
                answerVM.Answer = new Answer();
                if (question?.Answers?.Count != 4)
                {
                    return View(answerVM);
                }
                else 
                {
                    return RedirectToAction("Index", "Quiz");
                
                }
                
            }


            answerVM.Answer = new Answer();
            answerVM.Question = question;

            return View(answerVM);
        }
    }
}
