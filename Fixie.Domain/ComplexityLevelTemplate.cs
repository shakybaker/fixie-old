using System;
using System.Collections.Generic;

namespace Fixie.Domain
{
    public class ComplexityLevelTemplate : IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }

        public ComplexityLevelTemplate()
        {
            ComplexityLevels = new List<ComplexityLevel>();
        }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public IList<ComplexityLevel> ComplexityLevels { get; set; }
    }
}
