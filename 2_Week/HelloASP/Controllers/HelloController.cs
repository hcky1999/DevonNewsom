using Microsoft.AspNetCore.Mvc;

namespace HelloASP.Controllers
{
    public class HomeController : Controller
    {
        // Listen for Requests
        // GET localhost:5000/
       
        [HttpGet("")]
        // Deliver Responses
        public ViewResult Index()
        {
            // /Views/Home/Index.cshtml
            // /Views/Shared/Index.cshtml
            return View();
        }
        // route params!
        [HttpGet("{place}")]
        public IActionResult Place(string place)
        {
            // if the place is Taqueria, return a View
            if(place == "Taqueria")
                return View("Taqueria");
            // otherwise return a redirect back to index

            return RedirectToAction("Index");
        }
    }
}