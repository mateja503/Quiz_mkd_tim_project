using Microsoft.AspNetCore.Mvc;
using Quiz.Repository.Interface;

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
    }
}
