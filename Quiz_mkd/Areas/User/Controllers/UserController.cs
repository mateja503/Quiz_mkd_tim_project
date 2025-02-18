using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Identity;
using Quiz.Repository.Interface;
using Quiz.Utility;

namespace Quiz.Web.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IApplicationUserRepository _applicationUserRepository;


        public UserController(UserManager<IdentityUser> userManager, IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> RangList() 
        {
            var allUsers = _userManager.Users.ToList();
            var listUser = new List<IdentityUser>();
            foreach (var user in allUsers) 
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (!roles.Contains("Admin")) 
                {
                    listUser.Add(user);
                }
            }
            return View(listUser);
        }

    }
}
