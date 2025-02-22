using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Interface;
using Quiz.Utility;

namespace Quiz.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class EmailController : Controller
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IEmailSender _emailSender;


        public EmailController(IApplicationUserRepository applicationUserRepository, IEmailSender emailSender)
        {
            _applicationUserRepository = applicationUserRepository;
             _emailSender = emailSender;
        }

        public IActionResult Create()
        {
            EmailVM emailVM = new()
            {
                email = "",
                subject = "",
                htmlMessage="",
                emailsSent = false,
            };
            return View(emailVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmailVM emailVM)//if i want to place images in the email use tinyMice
        {
            var users = _applicationUserRepository.GetAll();

            foreach(var user in users) 
            {

                if (user.EmailConfirmed)
                {
                    await _emailSender.SendEmailAsync(user.Email, emailVM.subject, emailVM.htmlMessage);
                }


            }
            emailVM.emailsSent = true;

            return View(emailVM);
        }
    }
}
