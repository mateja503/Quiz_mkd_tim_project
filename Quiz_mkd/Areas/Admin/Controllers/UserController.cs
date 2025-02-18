using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Identity;
using Quiz.Repository.Interface;

namespace Quiz.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IApplicationUserRepository _applicationUserRepository;

      
        public UserController(UserManager<IdentityUser> userManager, IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userList = _userManager.Users.ToList();
            return View(userList);
        }


        public async Task<IActionResult> DeleteUser(string userId)
        {
            // Find the user by ID
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Delete the user
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index"); // Redirect to a success page or user list
            }

            // Handle errors
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("Error"); // Redirect to an error page
        }


    }
}
