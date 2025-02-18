using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Interface;

namespace Quiz.Web.Areas.Admin.Controllers
{
    public class TypeQuizController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeQuizController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var items = _unitOfWork.TypeQuiz.GetAll(includeProperties: "QuizList");
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TypeQuiz typeQuiz)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TypeQuiz.Add(typeQuiz);
                _unitOfWork.Save();
                return RedirectToAction("Index", "TypeQuiz");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var item = _unitOfWork.TypeQuiz.Get(u => u.Id == id, includeProperties: "QuizList");

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(TypeQuiz typeQuiz)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.TypeQuiz.Update(typeQuiz);
                _unitOfWork.Save();
                return RedirectToAction("Index", "TypeQuiz");
            }

            return View(typeQuiz);
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var item = _unitOfWork.TypeQuiz.Get(u => u.Id == id, includeProperties: "QuizList");

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteDB(int? id)
        {
            var item = _unitOfWork.TypeQuiz.Get(u => u.Id == id, includeProperties: "QuizList");

            if (item == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.TypeQuiz.Remove(item);
                _unitOfWork.Save();
                return RedirectToAction("Index", "TypeQuiz");
            }

            return View(item);
        }
    }
}
