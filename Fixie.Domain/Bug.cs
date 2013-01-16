using System;

namespace Fixie.Domain
{
    public class Bug : IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }

        public Bug()
        {
        }

        public Bug(int createdBy) : this()
        {
            CreatedBy = createdBy;
        }

        public string Description { get; set; }
    }
}
