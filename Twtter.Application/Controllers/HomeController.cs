using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twtter.Application.Controllers
{
    using Models;
    using Twitter.Data;

    public class HomeController : BaseController
    {
        private ITwitterData data;

        public HomeController()
            : this(new TwitterData(new TwitterDbContext()))
        {
            
        }

        public HomeController(ITwitterData data)
        {
            this.data = data;
        }
        public ActionResult Index()
        {
            var tweets = this.data.Tweets.All().Select(x=>x);
            return View(tweets);
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