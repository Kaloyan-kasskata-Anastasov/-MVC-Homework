namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public User()
        {
            this.UserTweets = new HashSet<Tweet>();
            this.UserFavoriteTweets = new HashSet<Tweet>();
        }

        public int ProfileId { get; set; }

        public virtual Profile UserProfile { get; set; }

        public virtual ICollection<Tweet> UserTweets { get; set; }

        public virtual ICollection<Tweet> UserFavoriteTweets { get; set; }
    }
}
