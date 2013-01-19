using System.Collections.Generic;
using Fixie.Domain;
using Fixie.Domain.Enumerators;

namespace Fixie.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Fixie.Models.FixieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Fixie.Models.FixieContext context)
        {
            var card = new Card
                {
                    Id = 1,
                    Name = "Test Card 1 Name",
                    Description = "This is the description",
                    Created = DateTime.Now,
                    CreatedBy = 1,
                    Modified = DateTime.Now,
                    ModifiedBy = 1,
                    Priority = new PriorityLevel
                        {
                            Id = 1,
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
                                            Id = 1,
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
                };

            //context.Cards.AddOrUpdate(a => a.Name, card);

            context.Boards.AddOrUpdate(a => a.Name, 
                new Board
                {
                    Id = 1,
                    Name = "Test Board 1",
                    Description = "Description of test board 1",
                    Lanes = new List<Lane>
                    {
                        new Lane
                        {
                            Id = 1,
                            Name = "Lane 1",
                            Sequence = 1,
                            Cards = new List<Card>
                            {
                                card
                            }
                        }
                    }
                }
            );
        }
    }
}
