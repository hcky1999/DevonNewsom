using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloModels.Models;

namespace HelloModels.Controllers
{
    public class HomeController : Controller
    {
        private List<Person> getPeople
        {
            get
            {
                List<Person> people = new List<Person>()
                {
                    new Person()
                    {
                        FirstName = "Devon",
                        LastName = "Newsom",
                        Location = "Texas",
                        DOB = new DateTime(1980, 2, 27)
                    },
                    new Person()
                    {
                        FirstName = "Sally",
                        LastName = "Silverstein",
                        Location = "Alberta",
                        DOB = new DateTime(1982, 6, 3)
                    },
                    new Person()
                    {
                        FirstName = "Debbie",
                        LastName = "Donuts",
                        Location = "Tallahasse, FL",
                        DOB = new DateTime(1973, 6, 3)
                    }
                };
                return people;
            }
        }

        [Route("")]
        // [HttpGet]
        public IActionResult Index()
        {

           // pass the view model in vvvvv
            return View(getPeople);
        }

        [HttpPost("process")]
        public IActionResult DoForm(Person newPerson)
        {
            var peeps = getPeople;
            peeps.Add(newPerson);
            return View("Index", peeps);
        }

    }
}
