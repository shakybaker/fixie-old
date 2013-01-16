using System;
using System.Collections.Generic;
using Fixie.Domain.Enumerators;

namespace Fixie.Domain
{
    public class Card : ICard, IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }

        public Card()
        {
            UserLinks = new List<UserLink>();
            Blockers = new List<Blocker>();
            Bugs = new List<Bug>();
            Scenarios = new List<Scenario>();
            Tasks = new List<Task>();
            SprintGoal = new SprintGoal();
            Priority = new PriorityLevel();
            Complexity = new ComplexityLevel();
        }

        public Card(int createdBy) : this()
        {
            CreatedBy = createdBy;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public ComplexityLevel Complexity { get; set; }
        public List<UserLink> UserLinks { get; set; }
        public List<Blocker> Blockers { get; set; }
        public List<Bug> Bugs { get; set; }
        public List<Scenario> Scenarios { get; set; }
        public List<Task> Tasks { get; set; }
        public SprintGoal SprintGoal { get; set; }

        public bool HasBugs()
        {
            return (Bugs.Count > 0);
        }
    }

    public class UserLink : IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }

        public User User { get; set; }
        public UserLinkType LinkType { get; set; }
    }
}
