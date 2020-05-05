using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mbekwa_Enterprise_Website.Models;
using Mbekwa_Enterprise_Website.Helpers;

namespace Mbekwa_Enterprise_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View("Contact", new Contact());
        }

        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            string content = "Name: " + contact.Name;
            content += "<br>Phone: " + contact.Phone;
            content += "<br>Message: " + contact.Message;

            if (MailHelper.Send(contact.EmailAddress, "sphafortunedube@outlook.com", contact.Subject, content))
            {
                ViewBag.message = "Success";
            }
            else
            {
                ViewBag.message = "Error";
            }
            return View("Contact");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
