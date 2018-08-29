using BME.BL;
using BME.DAL;
using Mongo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BlogManagementExample.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        IBlogService blogService;
        public HomeController(IBlogService _bs)
        {
            blogService = _bs;
        }

        
        public ActionResult Index()
        {
            return View(blogService.GetBlogs());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Blog blog)
        {
            blog.UserName = User.Identity.Name;
            blog.BlogDate =DateTime.Now;
            blogService.PostBlog(blog);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ? id)
        {   
            return View(blogService.FindBlog(id));
        }
        [HttpPost]
        public ActionResult Edit(Blog blog )
        {
            blogService.EditBlog(blog);
            return RedirectToAction("Index");
        }

        public ActionResult BlogShow(int? id)
        {
            return View(blogService.FindBlog(id));
        }

        public ActionResult ShowMongo()
        {
            var sqlBlogs = blogService.GetBlogs();
            List<BlogMongo> mongoBlogs = new List<BlogMongo>();
            foreach (var item in sqlBlogs)
            {
                BlogMongo mongo = new BlogMongo
                {
                    BlogTitle = item.BlogTitle,
                    BlogDate = item.BlogDate.ToString(),
                    Content = item.Content,
                    UserName = item.UserName,
                    Synced = item.Synced
                };
                mongoBlogs.Add(mongo);
            }
            blogService.PostMongo(mongoBlogs);
            return View(blogService.GetMongo());
        }
    }
}