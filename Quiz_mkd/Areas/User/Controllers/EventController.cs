using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Implementation;
using Quiz.Repository.Interface;

namespace Quiz.Web.Areas.User.Controllers
{

    [Area("User")]
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

    }
}
