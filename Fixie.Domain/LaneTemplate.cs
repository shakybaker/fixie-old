using System;
using System.Collections.Generic;

namespace Fixie.Domain
{
    public class LaneTemplate : IEntity
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public int ModifiedBy { get; set; }

        public LaneTemplate()
        {
            Lanes = new List<Lane>();
        }

        public string Name { get; set; }
        public IList<Lane> Lanes { get; set; }
        public string Description { get; set; }
    }
}
