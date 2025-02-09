using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Interface;

namespace Quiz.Web.Controllers
{
    public class EventController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public EventController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var items = _unitOfWork.Event.GetAll(includeProperties: "Quiz");
            return View(items);
        }

        public IActionResult Create()
        {
            
            var items = _unitOfWork.Quiz.GetAll(includeProperties: "Event").Where(u => u.Event == null).ToList(); 
            EventVM eventVM = new()
            {
                Event = new Event(),
                QuizList = items.Select(u => new SelectListItem
                {
                    Text = u?.Name,
                    Value = u?.Id.ToString()
                }).ToList(),
            };

            return View(eventVM);
        }

        [HttpPost]
        public IActionResult Create(EventVM itemVM)
        {


            if (ModelState.IsValid)
            {
                if (itemVM.Event.Id == 0) 
                {
                    _unitOfWork.Event.Add(itemVM.Event);
                    _unitOfWork.Save();
                    return RedirectToAction("Index", "Event");
                }
              
            }
            var items = _unitOfWork.Quiz.GetAll(includeProperties: "Event").Where(u => u.Event == null).ToList();
            itemVM.QuizList = items.Select(u=> new SelectListItem{ 
                Text = u.Name,
                 Value = u.Id.ToString()

            });
            return View(itemVM);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }
            var item = _unitOfWork.Event.Get(u => u.Id == id, includeProperties: "Quiz");
            if (item == null) 
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Event item)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Event.Update(item);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Event");
            }
            return View();
            
            
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = _unitOfWork.Event.Get(u => u.Id == id, includeProperties: "Quiz");
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeleteID(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = _unitOfWork.Event.Get(u => u.Id == id, includeProperties: "Quiz");
            if (item == null)
            {
                return NotFound();
            }

            _unitOfWork.Event.Remove(item);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Event");
        }

    }
}
