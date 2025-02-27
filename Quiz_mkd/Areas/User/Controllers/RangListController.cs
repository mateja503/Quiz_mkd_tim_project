using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Interface;

namespace Quiz.Web.Areas.User.Controllers
{
    [Area("User")]
    public class RangListController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public RangListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        //public IActionResult Index(int? eventId)
        //{

        //    var rangList = _unitOfWork.RangList
        //        .Get(u => u.EventId == eventId,includeProperties: "Event,Participants,Category_Users");

        //    List<Category> categories = new List<Category>();
        //    var categoriesRangList = _unitOfWork.Category_RangList.GetAll(u => u.RangListId == rangList.Id, includeProperties: "Category");
        //    foreach (var c in categoriesRangList) 
        //    {   
        //        categories.Add(c.Category);
        //    }
        //    RangListVM rangListVM = new RangListVM() {
        //        RangList = rangList,
        //        Categories = categories,    
        //    };

        //    return View(rangListVM);
        //}
    }
}
