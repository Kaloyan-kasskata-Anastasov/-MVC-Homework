using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twtter.Application.Controllers
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Models;
    using Twitter.Data;
    using Twitter.Models;

    [Authorize(Roles = "user")]
    public class UsersController : BaseController
    {
        public UsersController()
            : this(new TwitterData(new TwitterDbContext()))
        {
        }

        public UsersController(ITwitterData data)
            : base(data)
        {

        }
        public ActionResult Index(string username)
        {
            var user = User.Identity.GetUserId();
            var model = new TweetsListModel();

            var tweets = this.Data.Tweets.All()
                .Where(x => x.AuthorId == user).OrderByDescending(x => x.CreatedOn)
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


    }
}