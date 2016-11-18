using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class HomeController : Controller
    {
        private IMailService _mailService;
        private IWorldRepository _repository;
        private IConfigurationRoot _config;

        public HomeController(IMailService mailService, IWorldRepository repository, IConfigurationRoot config)
        {
            _config = config;
            _mailService = mailService;
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();

        }
        [Authorize]
        public IActionResult Trips()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("", "We don't support aol addresses");
            }
            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From TheWorld", model.Message);

                ModelState.Clear();
            }

            ViewBag.UserMessage = "Message Sent";

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
