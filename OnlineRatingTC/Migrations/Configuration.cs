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
            context.ReviewUsers.AddOrUpdate(p=>p.Name,
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

            context.ReviewRatingTypes.AddOrUpdate(p => p.ReviewRatingTypeName,
                new ReviewRatingType
                {
                    ReviewRatingTypeName = "Excellent"
                },
                new ReviewRatingType
                {
                    ReviewRatingTypeName = "Moderate"
                },
                new ReviewRatingType
                {
                    ReviewRatingTypeName = "Needs Improvement"
                }
            );

            context.ServiceTypes.AddOrUpdate(p => p.ServiceTypeName,
                new ServiceType
                {
                    ServiceTypeName = "service 1"
                },
                new ServiceType
                {
                    ServiceTypeName = "service 2"
                },

                new ServiceType
                {
                    ServiceTypeName = "service 3"
                }
            );
        }
    }
}
