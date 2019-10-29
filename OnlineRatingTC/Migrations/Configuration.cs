using OnlineRatingTC.Models;
using WebGrease.Css;

namespace OnlineRatingTC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineRatingTC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OnlineRatingTC.Models.ApplicationDbContext";
        }

        protected override void Seed(OnlineRatingTC.Models.ApplicationDbContext context)
        {
            context.Users.AddOrUpdate(p=>p.Name,
                new User
                {
                    Name = "Charles Tremblay",
                    City = "Ottawa",
                    Email = "ct@test.com"
                },
                new User
                {
                    Name = "John Smith",
                    City = "Ottawa",
                    Email = "js@test.com"
                },
                new User
                {
                    Name = "Sam Young",
                    City = "Ottawa",
                    Email = "sy@test.com"
                }
                );
        }
    }
}
