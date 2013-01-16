using System;

namespace Fixie.Domain
{
    public class ComplexityLevel : IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }

        public int Sequence { get; set; }
        public string Name { get; set; }
    }
}
