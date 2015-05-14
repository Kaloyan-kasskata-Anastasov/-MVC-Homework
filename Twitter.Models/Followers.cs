namespace Twitter.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FollowingFollower")]
    public class FollowingFollower
    {
        public int Id { get; set; }

        public string FollowerId { get; set; }

        public virtual User Follower { get; set; }
 
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
