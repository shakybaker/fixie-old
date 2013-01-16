using System;

namespace Fixie.Domain
{
    public class SprintGoal : IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }

        public SprintGoal()
        {
            GoalMet = false;
        }

        public SprintGoal(int createdBy) : this()
        {
            CreatedBy = createdBy;
        }

        public string Name { get; set; }
        public bool GoalMet { get; set; }
        public string WhyNotMet { get; set; }
    }
}
