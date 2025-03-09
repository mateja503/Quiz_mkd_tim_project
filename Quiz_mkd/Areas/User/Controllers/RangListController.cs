using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Interface;

namespace Quiz.Web.Areas.User.Controllers
{
    [Area("User")]
    public class RangListController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IApplicationUserRepository _applicationUserRepository;

        public RangListController(IUnitOfWork unitOfWork, IApplicationUserRepository applicationUserRepository)
        {
            _unitOfWork = unitOfWork;
            _applicationUserRepository = applicationUserRepository;
        }


        public IActionResult Index()
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
                ShowRangList = null,
            };

            return View(showRangListOpetionsVM);
        }


        [HttpPost]
        public IActionResult FilterRangList(ShowRangListOptionsVM showRangListOptionsVM)
        {
            var selectedEventId = showRangListOptionsVM.SelectedEventId;
            var selectedCategoryId = showRangListOptionsVM.SelectedCategoryId;
            var selectedYear = showRangListOptionsVM.SelectedYear;


            if (selectedEventId == null && selectedCategoryId == null && selectedYear == null) 
            {
                return RedirectToAction("Index", "RangList");
            }
            Event _event = null;

            if (selectedEventId != null) 
            {
                _event = _unitOfWork.Event.Get(u => u.Id == showRangListOptionsVM.SelectedEventId, includeProperties: "RangList");
            }
            RangList rangList = null;
            if (_event != null) 
            {
                rangList = _event.RangList;
            }

            List<RangList_User> rangListUsers = null;
            List<Category_RangList> categoryRangList = null;
            List<Category_User> categoryUsersForView = null;
            List<int> idsForRangList = null;


            if (rangList != null)
            {
                rangListUsers = _unitOfWork.RangList_User
                  .GetAll(u => u.RangListId == rangList.Id, includeProperties: "User")
                  .OrderByDescending(u => (double)u.Points).ToList();

                categoryRangList = _unitOfWork.Category_RangList
              .GetAll(u => u.RangListId == rangList.Id, includeProperties: "Category").ToList();

                categoryUsersForView = _unitOfWork.Category_User
                    .GetAll(u => u.RangListId == rangList.Id).ToList();
            }

            if (selectedCategoryId != null && rangList == null) 
            {
                categoryRangList = _unitOfWork.Category_RangList
                .GetAll(u => u.CategoryId == selectedCategoryId, includeProperties: "Category").ToList();

                categoryUsersForView = _unitOfWork.Category_User
                  .GetAll(u => u.CategoryId == selectedCategoryId).ToList();

                var distinctUsers = categoryUsersForView
                    .Select(u=>u.UserId)
                    .Distinct().ToList();
                //TODO 
                foreach (var i in distinctUsers) 
                {
                    var obj = _unitOfWork.RangList_User.Get(u => u.UserId == i);
                    rangListUsers.Add(obj);
                }
             
                //rangListUsers = _unitOfWork.RangList_User.GetAll(u=> )
            }


            

            
         
           

            RangListVM rangListVM = new RangListVM()
            {
                RangListUsers = rangListUsers,
                CategoriesRangList = categoryRangList,
                CategoryUsers = categoryUsersForView,
                Event = _event
            };

            ShowRangListOptionsVM showRangListOptionsVMfinal = new ShowRangListOptionsVM
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
                ShowRangList = rangListVM,
            };


            return View(showRangListOptionsVMfinal);
        }

    }
}
