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
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            // query for all posts
            List<Dictionary<string, object>> result = DbConnector.Query("SELECT * FROM posts");

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
