using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSecrets.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DojoSecrets.Controllers
{
    [Route("secrets")]
    public class SecretController : Controller
    {
        private int? SessionUserId
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
        }
        private SecretDashboard DashboardModel
        {
            get
            {
                return new SecretDashboard()
                {
                    RecentSecrets = dbContext.Secrets
                        .Include(s => s.Likes)
                        .OrderByDescending(s => s.CreatedAt)
                        .ToList(),
                    CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserId == SessionUserId)
                };
            }
        }
        private DojoSecretsContext dbContext;
        public SecretController(DojoSecretsContext context)
        {
            dbContext = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(DashboardModel);
        }
        [HttpPost("create")]
        public IActionResult Create(Secret newSecret)
        {
            if(ModelState.IsValid)
            {
                dbContext.Secrets.Add(newSecret);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", DashboardModel);
        }
        [HttpGet("delete/{secretId}")]
        public IActionResult Delete(int secretId)
        {
            // query for secret to delete (with SecretId AND UserId)
            Secret toDelete = dbContext.Secrets.FirstOrDefault(s => s.SecretId == secretId && s.UserId == SessionUserId);
            if(toDelete != null)
            {
                dbContext.Secrets.Remove(toDelete);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet("like/{secretId}")]
        public IActionResult Like(int secretId)
        {
            // add a like to the like table!
            // (create a Like object)
            Like newLike = new Like();
            newLike.SecretId = secretId;
            newLike.UserId = (int)SessionUserId;
            // add that Like object/SaveChanges()
            dbContext.Likes.Add(newLike);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet("unlike/{secretId}")]
        public IActionResult UnLike(int secretId)
        {
            // query for like to delete (with SecretId AND UserId)
            Like toDelete = dbContext.Likes.FirstOrDefault(l => l.SecretId == secretId && l.UserId == SessionUserId);
            if(toDelete != null)
            {
                dbContext.Likes.Remove(toDelete);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    
    }   
}
