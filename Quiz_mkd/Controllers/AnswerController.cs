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

        //public IActionResult Create() 
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(AnswerVM item)
        //{
    
        //    if (ModelState.IsValid) 
        //    {
        //        if (item.Answer != null) 
        //        {
        //            _unitOfWork.Answer.Add(item.Answer);
        //        }
        //        if (item?.Question?.Text != null) 
        //        {

        //        }
                
        //        _unitOfWork.Save();
        //        return RedirectToAction("Index", "Answer");
        //    }

            
        //    return View();
        //}
    }
}
