using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsSite.Models;

namespace NewsSite.Controllers
{
    public class HomeController : Controller
    {
        AuthorContext db = new AuthorContext();
        public ActionResult Index()
        {
            var articles = db.Articles;
            ViewBag.Articles = articles;
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddArticle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddArticle(Article art)
        {
            art.Date = DateTime.Now;

            db.Articles.Add(art);
            db.SaveChanges();
            return View("Index");
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
    }
}