using System;

namespace Fixie.Domain
{
    public class Blocker : IEntity
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public int ModifiedBy { get; set; }
    }
}
