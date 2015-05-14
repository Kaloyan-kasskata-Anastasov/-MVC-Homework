using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    using Microsoft.Win32;

    public class Tweet
    {
        public Tweet()
        {
            this.TweetFavoriteUsers = new HashSet<User>();
            this.Answers = new HashSet<Tweet>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Url { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<User> TweetFavoriteUsers { get; set; }

        public virtual ICollection<Tweet> Answers { get; set; }
    }
}
