namespace Twitter.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;

    using System.Net.Mime;
    using Glimpse.AspNet.Extensions;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Twitter.Data.TwitterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Twitter.Data.TwitterDbContext context)
        {
            if (! context.Users.Any())
            {
                User one = new User()
                {
                    UserName = "Gogo",
                    Email = "main@main.com",
                    PasswordHash = "770f31f6-3750-41c8-b512-652ad5f11814"
                };
                context.Users.Add(one);
                User two = new User()
                {
                    UserName = "Mogo",
                    Email = "main@main.com",
                    PasswordHash = "770f31f6-3750-41c8-b512-652ad5f11814"
                };
                context.Users.Add(two);
                User three = new User()
                {
                    UserName = "Vogo",
                    Email = "main@main.com",
                    PasswordHash = "770f31f6-3750-41c8-b512-652ad5f11814"
                };
                context.Users.Add(three);
                Tweet twOne = new Tweet()
                {
                    Author = one,
                    Text = "First tweet text",
                    Title = "Tweet One",
                };
                context.Tweets.Add(twOne);
                Tweet twTwo = new Tweet()
                {
                    Author = two,
                    Text = "Second tweet text",
                    Title = "Tweet Two",
                };
                context.Tweets.Add(twTwo);
                FollowingFollower folowOne = new FollowingFollower()
                {
                    Author = one,
                    Follower = two
                };
                
                FollowingFollower folowTwo = new FollowingFollower()
                {
                    Author = one,
                    Follower = three
                };
            }
        }
    }
}
