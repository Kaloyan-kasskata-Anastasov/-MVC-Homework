using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twtter.Application.Models
{
    using Twitter.Models;

    public class UserViewModel
    {
        public Profile UserProfile { get; set; }

        public ICollection<Tweet> UserTweets { get; set; }

        public ICollection<Tweet> UserFavoriteTweets { get; set; }

        public ICollection<User> UserFollowers { get; set; }

        public ICollection<User> FollowingUsers { get; set; }
    }
}