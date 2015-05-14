﻿namespace Twitter.Data
{
    using Models;
    using Repositories;

    public interface ITwitterData
    {
        IRepository<User> Users { get; }

        IRepository<Tweet> Tweets { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Profile> Profiles { get; }

        IRepository<FollowingFollower> Follows { get; } 

        int SaveChanges();
    }
}
