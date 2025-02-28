using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
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


        public IActionResult Index(RangListVM? rangListVM = null)
        {

            ShowRangListOptionsVM showRangListOpetionsVM = new ShowRangListOptionsVM
            {
                Events = _unitOfWork.Event.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Categories = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.categoryName,
                    Value = u.Id.ToString()
                }),
                EventsByYear = _unitOfWork.Event.GetAll().Select(u => u.StartDate.Year).Distinct().OrderBy(u => u)
                .Select(u => new SelectListItem
                {
                    Text = u.ToString(),
                    Value = u.ToString()

                }),
                ShowRangList = rangListVM

            };

            return View(showRangListOpetionsVM);
        }

        [HttpPost]
        public IActionResult FilterRangList(ShowRangListOptionsVM showRangListOpetionsVM)
        {
            var _event = _unitOfWork.Event.Get(u => u.Id == showRangListOpetionsVM.SelectedEventId, includeProperties: "RangList");

            var rangList = _event.RangList;

            var rangListUsers = _unitOfWork.RangList_User
                .GetAll(u => u.RangListId == rangList.Id, includeProperties: "User").ToList();

            var categoryRangList = _unitOfWork.Category_RangList
                .GetAll(u => u.RangListId == rangList.Id, includeProperties: "Category").ToList();

            var categoryUsersForView = _unitOfWork.Category_User
                .GetAll(u => u.RangListId == rangList.Id).ToList();



            RangListVM rangListVM = new RangListVM()
            {
                RangListUsers = rangListUsers,
                CategoriesRangList = categoryRangList,
                CategoryUsers = categoryUsersForView,
                Event = _event
            };

            return RedirectToAction("Index","RangList",new { araa="User", rangListVM = rangListVM } );
        }
    }
}
