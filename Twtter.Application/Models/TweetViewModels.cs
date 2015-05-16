namespace Twtter.Application.Models
{
    using System.Collections.Generic;
    using Twitter.Models;

    public class TweetOutputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string AuthorId { get; set; }

        public string UserName { get; set; }
    }

    public class TweetsListModel
    {
        public TweetsListModel()
        {
            Tweets = new List<Tweet>();
        }
        public List<Tweet> Tweets { get; set; }
    }

    public class TweetByIdViewModel
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string Url { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<User> TweetFavoriteUsers { get; set; }

        public virtual ICollection<Tweet> Answers { get; set; }
    }
}