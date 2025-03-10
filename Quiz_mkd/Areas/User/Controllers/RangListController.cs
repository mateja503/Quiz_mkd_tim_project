using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NuGet.Versioning;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Implementation;
using Quiz.Repository.Interface;
using System.Net.WebSockets;

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

            Event _event = null;
            RangList rangList = null;

            List<RangList_User> rangListUsers = new List<RangList_User>();
            List<Category_RangList> categoryRangList = new List<Category_RangList>();
            List<Category_User> categoryUsersForView = new List<Category_User>();
            List<int> idsForRangList = null;


            //all of the fields are not selected 
            if (selectedEventId == null && selectedCategoryId == null && selectedYear == null)
            {
                return RedirectToAction("Index", "RangList");
            }

            //only the event field is selected
            if (selectedEventId != null && selectedCategoryId == null && selectedYear == null)
            {
                _event = _unitOfWork.Event.Get(u => u.Id == selectedEventId, includeProperties: "RangList");

                rangList = _event.RangList;

                rangListUsers = _unitOfWork.RangList_User
                .GetAll(u => u.RangListId == rangList.Id, includeProperties: "User")
                .OrderByDescending(u => (double)u.Points).ToList();

                categoryRangList = _unitOfWork.Category_RangList
              .GetAll(u => u.RangListId == rangList.Id, includeProperties: "Category").ToList();

                categoryUsersForView = _unitOfWork.Category_User
                    .GetAll(u => u.RangListId == rangList.Id).ToList();

            }

            //only the category field is selected
            if (selectedEventId == null && selectedCategoryId != null && selectedYear == null)
            {
                categoryRangList = _unitOfWork.Category_RangList
                .GetAll(u => u.CategoryId == selectedCategoryId, includeProperties: "Category")
                .ToList();

                var rangIdsList = categoryRangList.DistinctBy(u => u.RangListId).Select(u => u.RangListId).ToList();
                categoryRangList = categoryRangList.DistinctBy(u => u.CategoryId).ToList();

                rangListUsers = _unitOfWork.RangList_User
                       .GetAll(u => rangIdsList.Contains(u.RangListId), includeProperties: "User")
                       .DistinctBy(u => u.UserId)
                       .ToList();


                var userIds = rangListUsers.DistinctBy(u => u.UserId).Select(u => u.UserId).ToList();

                var userTotalPointsPerCategory = _unitOfWork.UserTotalPointsPerCategory
                    .GetAll(u => u.CategoryId == selectedCategoryId);
               
                List<Category_User> l = new List<Category_User>();
                foreach (var n in userTotalPointsPerCategory)
                {
                    var obj = new Category_User
                    {
                        UserId = n.UserId,
                        CategoryId = selectedCategoryId,
                        Points = n.Points,
                    };
                    l.Add(obj);
                }
                
                 
                var orderedCategoryUsers = l.OrderByDescending(u=>u.Points).ThenByDescending(u=>u.UserId).ToList();

                rangListUsers = rangListUsers
                    .Join(orderedCategoryUsers, r => r.UserId, c => c.UserId, (r, c) =>
                    new {
                        RangList_User = r, Category_User = c
                    })
                    .OrderByDescending(x => x.Category_User.Points)
                    .ThenByDescending(x => x.RangList_User?.User?.Surname)
                    .Select(x => x.RangList_User)
                    .ToList();



                categoryUsersForView = orderedCategoryUsers;
            }

            //only the year field is selected 
            if (selectedEventId == null && selectedCategoryId == null && selectedYear != null)
            {
                int year = int.Parse(selectedYear);
                var _events = _unitOfWork.Event.GetAll(u => u.StartDate.Year == year, includeProperties: "RangList");
                List<RangList_User> listForRangListUsers = new List<RangList_User>();
                List<Category_RangList> listForCategoryRangList = new List<Category_RangList>();
                List<Category_User> listForCategoryUser = new List<Category_User>();

                List<RangList_User> tempRangListUsers = new List<RangList_User>();
                List<Category_RangList> tempCategoryRangList = new List<Category_RangList>();
                List<Category_User> tempCategoryUser = new List<Category_User>();

                foreach (var e in _events) 
                {
                    rangList = e.RangList;

                    tempRangListUsers = _unitOfWork.RangList_User
                    .GetAll(u => u.RangListId == rangList.Id, includeProperties: "User").ToList();


                    tempCategoryRangList = _unitOfWork.Category_RangList
                    .GetAll(u => u.RangListId == rangList.Id, includeProperties: "Category").ToList();

                    tempCategoryUser = _unitOfWork.Category_User
                    .GetAll(u => u.RangListId == rangList.Id).ToList();


                    listForRangListUsers.AddRange(tempRangListUsers);
                    listForCategoryRangList.AddRange(tempCategoryRangList);
                    listForCategoryUser.AddRange(tempCategoryUser);
                }
                var distinctUsers = listForRangListUsers.DistinctBy(u => u.UserId).ToList();
                var distinctCategories = listForCategoryRangList.DistinctBy(u => u.CategoryId).ToList();
                Dictionary<string,double?> userRangListPoints = new Dictionary<string,double?>();
                Dictionary <string, Dictionary<int?, double?>> userCategoryPoints = new Dictionary<string, Dictionary<int?, double?>>();

                foreach (var user in distinctUsers) 
                {
                    userRangListPoints.Add(user.UserId, 0.0);
                    userCategoryPoints.Add(user.UserId, new Dictionary<int?, double?>());

                    foreach (var category in distinctCategories)
                    {
                        userCategoryPoints[user.UserId].Add(category.Id, 0.0);
                    }

                }

               
                foreach (var n in listForRangListUsers) 
                {
                    userRangListPoints[n.UserId] += n.Points;
                }
                userRangListPoints = userRangListPoints.OrderByDescending(u => u.Value).ToDictionary();



                foreach (var n in listForCategoryUser) 
                {
                    userCategoryPoints[n.UserId][n.CategoryId] += n.Points;
                }

                //TODO

                foreach (var n in userRangListPoints) 
                {
                    rangList =
                }
                 

                List<Category_RangList> categoryRangList = new List<Category_RangList>();
                List<Category_User> categoryUsersForView = new List<Category_User>();



            }
            //the event & category filds are selected 
            if (selectedEventId != null && selectedCategoryId != null && selectedYear == null)
            {

            }
            //the event & year fields are selected 
            if (selectedEventId != null && selectedCategoryId == null && selectedYear != null)
            {

            }

            //the category & year are selected
            if (selectedEventId == null && selectedCategoryId != null && selectedYear != null)
            {

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
