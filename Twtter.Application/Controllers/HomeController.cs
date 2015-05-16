using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Twtter.Application.Controllers
{
    using Models;
    using Twitter.Data;
    using Twitter.Models;

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
            var model = new TweetsListModel();
            var tweets = this.data.Tweets.All()
                .Select(x => x).OrderByDescending(x => x.CreatedOn)
                .ToList();

            foreach (var tweet in tweets)
            {
                model.Tweets.Add(new Tweet
                {
                    Id = tweet.Id,
                    Title = tweet.Title,
                    Text = tweet.Text,
                    Author = tweet.Author,
                    CreatedOn = tweet.CreatedOn
                });
            }

            return View(model);
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