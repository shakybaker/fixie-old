using System;
using System.Collections.Generic;

namespace Fixie.Domain
{
    public class PriorityLevelTemplate : IEntity
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public int ModifiedBy { get; set; }

        public PriorityLevelTemplate()
        {
            PriorityLevels = new List<PriorityLevel>();
        }

        public string Name { get; set; }
        public IList<PriorityLevel> PriorityLevels { get; set; }
        public string DisplayName { get; set; }
    }
}
