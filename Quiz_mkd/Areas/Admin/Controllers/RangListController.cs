using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.Identity;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Implementation;
using Quiz.Repository.Interface;
using Quiz.Utility;
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

        public IActionResult PendingUsers(int? eventId)
        {
            List <ApplicationUserVM> users = new List<ApplicationUserVM>();

            var eventUsers = _unitOfWork.Event_User.GetAll(u => u.EventId == eventId, includeProperties: "User").ToList();

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

        public IActionResult PayedToParticipate(string? userId,int? eventId) 
        {

            var rangList = _unitOfWork.RangList.Get(u => u.EventId == eventId);

            RangList_User rangList_User = new RangList_User() { 
                UserId = userId,
                RangListId = rangList.Id,

            };
            _unitOfWork.RangList_User.Add(rangList_User);
            _unitOfWork.Save();

            var event_user = _unitOfWork.Event_User.Get(u => u.EventId == eventId && u.UserId == userId);

            //_unitOfWork.Event_User.Remove(event_user);
            //_unitOfWork.Save();


            return RedirectToAction("PendingUsers", "RangList", new { area = "Admin", eventId = eventId });
        }

        public IActionResult EditTable(int? eventId) 
        {
            var rangList = _unitOfWork.RangList.Get(u => u.EventId == eventId);
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
                    isPartOfTheTable = flag
                };
                categoryListVM.Add(categoryVM);
            }

            return View(categoryListVM);
        
        }
    }
}
