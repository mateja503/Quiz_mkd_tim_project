using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.Identity;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Implementation;
using Quiz.Repository.Interface;
using Quiz.Utility;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Quiz.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class RangListController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public RangListController(IUnitOfWork unitOfWork, IApplicationUserRepository applicationUserRepository)
        {
            _unitOfWork = unitOfWork;
            _applicationUserRepository = applicationUserRepository;
        }

        public IActionResult Index(int? eventId)
        {
            var _event = _unitOfWork.Event.Get(u => u.Id == eventId, includeProperties:"RangList");

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

            return View(rangListVM);
        }

        public IActionResult PendingUsers(int? eventId)
        {
            List<ApplicationUserVM> users = new List<ApplicationUserVM>();

            var eventUsers = _unitOfWork.EventPending_User.GetAll(u => u.EventId == eventId, includeProperties: "User").ToList();

            foreach (var user in eventUsers)
            {
                var _userVM = new ApplicationUserVM()   
                {
                    User = user.User,
                    EventId = eventId
                };
                users.Add(_userVM);
            }
            return View(users);
        }

        public IActionResult PayedToParticipate(string? userId, int? eventId)
        {

            var rangList = _unitOfWork.RangList.Get(u => u.EventId == eventId);

            RangList_User rangList_User = new RangList_User() {
                UserId = userId,
                RangListId = rangList.Id,

            };
            _unitOfWork.RangList_User.Add(rangList_User);
            _unitOfWork.Save();
         

            var categoryRangList = _unitOfWork.Category_RangList
               .GetAll(u => u.RangListId == rangList.Id, includeProperties: "Category").ToList();

                foreach (var category in categoryRangList)
                {
                    var categoryUser = new Category_User()
                    {
                        CategoryId = category.CategoryId,
                        UserId = userId,
                        RangListId = rangList.Id
                    };
                    _unitOfWork.Category_User.Add(categoryUser);
                    _unitOfWork.Save();


                }
             
            
            var eventPending_User = _unitOfWork.EventPending_User
                .Get(u => u.UserId == userId && u.EventId == eventId);
            _unitOfWork.EventPending_User.Remove(eventPending_User);
            _unitOfWork.Save();


            return RedirectToAction("PendingUsers", "RangList", new { area = "Admin", eventId = eventId  });
        }

        public IActionResult EditTable(int? eventId = null,int? rangListId = null)
        {
            var rangList = _unitOfWork.RangList.Get(u => u.EventId == eventId);
            if (rangListId != null)
            {
                rangList = _unitOfWork.RangList.Get(u => u.Id == rangListId);
            }
         

            var categories = _unitOfWork.Category.GetAll();
            List<CategoryVM> categoryListVM = new List<CategoryVM>();
            var categoryRangList = _unitOfWork.Category_RangList
                .GetAll(u => u.RangListId == rangList.Id, includeProperties: "Category").ToList();

            List<Category> categoriesInRangList = new List<Category>();
            foreach (var item in categoryRangList)
            {
                categoriesInRangList.Add(item.Category);
            }
            foreach (var category in categories)
            {
                bool flag = categoriesInRangList.Contains(category);


                CategoryVM categoryVM = new CategoryVM()
                {
                    Category = category,
                    isPartOfTheTable = flag,
                    RangListId = rangList.Id
                };
                categoryListVM.Add(categoryVM);
            }

            return View(categoryListVM);

        }

        public IActionResult AddToRangList(int? categoryId, int? rangListId) 
        {
            var categoryRangList = new Category_RangList()
            {
                CategoryId = categoryId,
                RangListId = rangListId
            };
            _unitOfWork.Category_RangList.Add(categoryRangList);
            _unitOfWork.Save();

            var usersId = _unitOfWork.Category_User.GetAll(u => u.RangListId == rangListId)
                .Select(u => u.UserId)
                .Distinct()
                .ToList();

            foreach (var userId in usersId) 
            {
                var categoryUser = new Category_User() 
                {
                    UserId = userId,
                    CategoryId = categoryId,
                    RangListId = rangListId
                };
                _unitOfWork.Category_User.Add(categoryUser);
                _unitOfWork.Save();
            }

            return RedirectToAction("EditTable", "RangList", new { area = "Admin",rangListId = rangListId });
        }

        public IActionResult RemoveFromRangList(int? categoryId, int? rangListId)
        {
            var categoryRangList = _unitOfWork.Category_RangList
                .Get(u => u.CategoryId == categoryId && u.RangListId == rangListId);

            _unitOfWork.Category_RangList.Remove(categoryRangList);
            _unitOfWork.Save();


            var categoryUsers = _unitOfWork.Category_User.GetAll(u => u.RangListId == rangListId && u.CategoryId == categoryId);

            _unitOfWork.Category_User.RemoveRange(categoryUsers);
            _unitOfWork.Save();
            
            return RedirectToAction("EditTable", "RangList", new { area = "Admin", rangListId = rangListId });
        }

        public IActionResult AddPointsToUser(string? userId, int? eventId) 
        {
            var _event = _unitOfWork.Event.Get(u => u.Id == eventId, includeProperties: "RangList");

            var rangList = _event.RangList;

            var categoryUsers = _unitOfWork.Category_User
                .GetAll(u=> u.RangListId==rangList.Id && u.UserId == userId, includeProperties: "Category,User").ToList();

            var user = categoryUsers?.FirstOrDefault()?.User;

            RangListVM rangListVM = new RangListVM()
            {
                CategoryUsers = categoryUsers,
                Event = _event,
                User = user
            };


            return View(rangListVM);
            //return RedirectToAction("Index","RangList", new { area = "Admin", eventId = eventId });


        }

        [HttpPost]
        [Display(Name = "AddPointsToUser")]
        public IActionResult AddPointsToUserDB(string? userId, int? eventId)
        {
            return View();


        }




    }
}
