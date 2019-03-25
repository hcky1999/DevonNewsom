using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataPassing.Models;

namespace DataPassing.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        // [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Name = "Devon";
            ViewBag.Location = "Texas";
            return View();
        }

        [HttpPost("process")]
        public IActionResult DoForm(string firstName, string lastName, string location)
        {
            ViewBag.Name = $"{firstName} {lastName}";
            ViewBag.Location = location;
            return View("Index");
        }

    }
}
