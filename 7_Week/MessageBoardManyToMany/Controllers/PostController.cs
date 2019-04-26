using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Controllers
{
    [Route("posts")]
    public class PostController : Controller
    {
        private int? SessionUserId
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
        }
        private MessageBoardContext dbContext;
        public PostController(MessageBoardContext context)
        {
            dbContext = context;
        }
        // localhost:5000/posts/
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            if(SessionUserId == null)
                return RedirectToAction("Login", "Home");
         
            var resultFromEF = dbContext.Posts
                .Include(p => p.Creator)
                .Include(p => p.Votes)
                .ToList();

            ViewBag.UserId = SessionUserId;


            DateTime todayStart = DateTime.Now.Date;
            DateTime todayEnd = todayStart.AddDays(1);

        
            // provide them to my Index.cshtml
            return View(resultFromEF);
        }
        [HttpGet("{postId}")]
        public IActionResult Show(int postId)
        {
            var model = dbContext.Posts
                .Include(p => p.Votes)
                .ThenInclude(v => v.Voter)
                .FirstOrDefault(p => p.PostId == postId);

            return View(model);
        }
        // localhost:5000/posts/new
        [HttpGet("new")]
        public IActionResult New()
        {
            if(SessionUserId == null)
                return RedirectToAction("Login", "Home");

            // ALL USERS QUERY
            ViewBag.AllUsers = dbContext.Users.ToList();
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(Post post)
        {
            if(ModelState.IsValid)
            {
                // post.UserId = (int)SessionUserId;
                // we will add new post to the DB!
                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
             
                return RedirectToAction("Index");
            }
            // ModelState contains the error info
            return View("New");
        }
        [HttpGet("delete/{postId}")]
        public IActionResult Delete(int postId)
        {
            if(SessionUserId == null)
                return RedirectToAction("Login", "Home");
            // first, query for thing to delete
            Post toDelete = dbContext.Posts.FirstOrDefault(p => p.PostId == postId);
            if(toDelete == null)
                return RedirectToAction("Index");

            dbContext.Posts.Remove(toDelete);
            dbContext.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpGet("edit/{postId}")]
        public IActionResult Edit(int postId)
        {
            if(SessionUserId == null)
                return RedirectToAction("Login", "Home");
            // query for a post
            Post post = dbContext.Posts.FirstOrDefault(p => p.PostId == postId);
            return View("EditPost", post);
        }

        [HttpPost("update/{postId}")]
        public IActionResult Update(Post post, int postId)
        {
            if(ModelState.IsValid)
            {
                // query for a post to update
                Post toUpdate = dbContext.Posts.FirstOrDefault(p => p.PostId == postId);
                toUpdate.Topic = post.Topic;
                toUpdate.Content = post.Content;
                toUpdate.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("EditPost", post);


        }

        [HttpGet("vote/{postId}/{isUpvote}")]
        public IActionResult Vote(int postId, bool isUpvote)
        {
            // instantiate a Vote object

            Vote newVote = new Vote();
            newVote.UserId = (int)SessionUserId;
            newVote.PostId = postId;
            newVote.IsUpvote = isUpvote;
            // set fields on it
            dbContext.Votes.Add(newVote);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }   
}
