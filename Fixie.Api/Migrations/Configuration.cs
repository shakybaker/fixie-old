namespace Fixie.Api.Migrations
{
    using Fixie.Domain;
    using Fixie.Domain.Enumerators;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Fixie.Api.Models.FixieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Fixie.Api.Models.FixieContext context)
        {
            context.Cards.AddOrUpdate(a => a.Name,
                new Card
                {
                    Name = "Test Card 1 Name",
                    Description = "This is the description",
                    Created = DateTime.Now,
                    CreatedBy = 1,
                    Modified = DateTime.Now,
                    ModifiedBy = 1,
                    Priority = new PriorityLevel
                    {
                        Name = "High",
                        Sequence = 1
                    },
                    UserLinks = new List<UserLink>
                    {
                        new UserLink
                        {
                            LinkType = UserLinkType.Creator,
                            User = new User
                            {
                                Username = "shakybaker",
                                Forename = "Mark",
                                Surname = "Baker",
                                Email = "shakybaker@gmail.com",
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            }
                        }
                    }
                });
        }
    }
}
