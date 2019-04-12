using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;
using DbConnection;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        // Entity Framework Connection
        private MessageBoardContext dbContext;
        public HomeController(MessageBoardContext context) {
            dbContext = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            // query for all posts
            List<Dictionary<string, object>> result = DbConnector.Query("SELECT * FROM posts ORDER BY Username");

            // query for all posts (Entity Framework)
            var posts = dbContext.Posts.OrderBy(p => p.Username).ToList();

            var postById = dbContext.Posts.FirstOrDefault(post => post.PostId == 2);




            ViewBag.Posts = result;
            // provide them to my Index.cshtml
            return View();
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(Post post)
        {
            if(ModelState.IsValid)
            {
                // we will add new post to the DB!
                string insertQuery = $"INSERT INTO posts (Username, Topic, Content, CreatedAt, UpdatedAt) VALUES (\"{post.Username}\", \"{post.Topic}\", \"{post.Content}\", NOW(), NOW());";
                DbConnector.Execute(insertQuery);
                return RedirectToAction("Index");
            }
            // ModelState contains the error info
            return View("New");
        }
    }   
}
