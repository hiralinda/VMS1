using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VMS.Data;
using VMS.Models;
using VMS.Models.ViewModels;

namespace VMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExploreCauses()
        {
            return View();
        }

        public IActionResult VolunTeenBlog(PostsViewModel model)
        {
            model.Posts = _context.Post.ToList().OrderByDescending(s => s.DatePosted);
            return View(model);
        }

        public async Task<IActionResult> CreatePost(Post post, IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await files.CopyToAsync(stream);
                        post.Image = stream.ToArray();
                    }

                }
            }

            post.DatePosted = DateTime.UtcNow;
            post.CreateUser = await _context.Users.SingleOrDefaultAsync(t => t.Id == User.Id());
            post.CreateUserName = post.CreateUser.UserName;
            post.ProfilePicture = post.CreateUser.ProfilePicture;
            post.TotalLikes = 0;
            _context.Add(post);
            await _context.SaveChangesAsync();
            TempData["message"] = $"Blog Post Created!";
            return RedirectToAction(nameof(VolunTeenBlog));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult RegisterOption()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        [HttpPost, ActionName("deletePost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {

            var post = await _context.Post.FindAsync(id);

            _context.Post.Remove(post);

            await _context.SaveChangesAsync();

            TempData["message"] = $"Post Deleted!";
            return RedirectToAction(nameof(VolunTeenBlog));
        }
    }
}
