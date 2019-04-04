using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SessionTimes.Controllers
{
    public class HomeController : Controller
    {
        const string NAME_KEY = "player";
        private int? SessionCount
        {
            get { return HttpContext.Session.GetInt32("count"); }
            set { HttpContext.Session.SetInt32("count", (int)value); }
        }

        private int? SessionGold
        {
            get { return HttpContext.Session.GetInt32("gold"); }
            set { HttpContext.Session.SetInt32("gold", (int)value); }
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString(NAME_KEY) == null)
            {
                HttpContext.Session.SetString(NAME_KEY, "New Player");
            }
            ViewBag.PlayerName = HttpContext.Session.GetString(NAME_KEY);

            // first time user check
            if(SessionCount == null)
            {
                // first time: put 0 in session
                SessionCount = 0;
            }

            ViewBag.Count = SessionCount;

            return View();
        }

        [HttpGet("count")]
        public IActionResult Count()
        {
            // todo: increment count
            // step 1: get value
            int? currCount = HttpContext.Session.GetInt32("count");
            // step 2: increment value
            currCount++;
            // step 3: set value
            HttpContext.Session.SetInt32("count", (int)currCount);

            // SessionCount = SessionCount + 1;
            // SessionCount++;

            return RedirectToAction("Index");
        }
        [HttpPost("newPlayer")]
        public IActionResult NewPlayer(string player)
        {
            // todo: handle session player
            HttpContext.Session.SetString(NAME_KEY, player);
            return RedirectToAction("Index");
        }
        [HttpGet("reset")]
        public IActionResult Reset()
        {
            TempData["resetMessage"] = "Thanks for playing!";
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("ninja")]
        public IActionResult NinjaGold()
        {
            if(SessionGold == null)
                SessionGold = 0;

            ViewBag.TotalGold = SessionGold;
            return View();
        }

        [HttpPost("gold")]
        public IActionResult Golding(string building)
        {
            Random r = new Random();
            int currGold;
            // Get (1 - 3) golds from the Cave
            if(building == "cave")
            {
                currGold = r.Next(1, 4);
            }
            // Get (2 - 5) golds from the House
            else if(building == "house")
            {
                currGold = r.Next(2, 6);
            }
            // Get (10 - 20) golds from the Farm
            else if(building == "farm")
            {
                currGold = r.Next(10, 20);

            }
            // Get/Lost (0 - 50) golds from the Casino
            else
            {
                currGold = r.Next(-50, 50);
            }
            SessionGold += currGold;

            string message = $"You got {currGold} from the {building}";
            TempData["goldMessage"] = message;
            return RedirectToAction("NinjaGold");
        }
    }
}
