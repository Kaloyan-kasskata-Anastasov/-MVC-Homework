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
            if (!context.Users.Any())
            {
                AddRolesToDb(context);
            }
        }
        private void AddRolesToDb(TwitterDbContext context)
        {
            var storeRole = new RoleStore<IdentityRole>(context);
            var managerRole = new RoleManager<IdentityRole>(storeRole);
            var adminRole = new IdentityRole { Name = "admin" };
            var userRole = new IdentityRole { Name = "user" };
            var moderatorRole = new IdentityRole { Name = "moderator" };
            managerRole.Create(adminRole);
            managerRole.Create(userRole);
            managerRole.Create(moderatorRole);

            var storeUser = new UserStore<User>(context);
            var managerUser = new UserManager<User>(storeUser);

            var admin = new User { UserName = "admin@admin.a", Email = "admin@admin.a" };
            var moderator = new User { UserName = "moderator@mod.m", Email = "moderator@mod.m" };
            var resultUser = managerUser.Create(admin, "Aa#123456");
            var resultmod = managerUser.Create(moderator, "Aa#123456");
            context.SaveChanges();

            var adminResult = context.Users.FirstOrDefault(x => x.UserName == "admin@admin.a");
            var moderatorResult = context.Users.FirstOrDefault(x => x.UserName == "moderator@mod.m");
            managerUser.AddToRole(adminResult.Id, "admin");
            managerUser.AddToRole(moderatorResult.Id, "moderator");
            context.SaveChanges();

        }
    }
}
