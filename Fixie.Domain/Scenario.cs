using System;
using System.Collections.Generic;

namespace Fixie.Domain
{
    public class Scenario : IEntity
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public int ModifiedBy { get; set; }

        public Scenario()
        {
            Bugs = new List<Bug>();
        }

        public Scenario(int createdBy) : this()
        {
            CreatedBy = createdBy;
        }

        public string Description { get; set; }
        public List<Bug> Bugs { get; set; }
    }
}
