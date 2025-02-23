﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Quiz.Domain.Domain_Models;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Implementation;
using Quiz.Repository.Interface;
using Quiz.Utility;

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

            var items = _unitOfWork.Event.GetAll();
            items = items.OrderBy(u => u?.StartDate).ToList();

            //EventUserVM eventUserVm =  

            return View(items);
        }

        public IActionResult Detail(int? eventId) 
        {
            var item = _unitOfWork.Event.Get(u => u.Id == eventId);
            return View(item);
        }

        public IActionResult RegisterEvent(int? eventId)
        {



            return View();
        }

    }
}
