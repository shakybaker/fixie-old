using System;

namespace Fixie.Domain
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }

        public Comment()
        {
        }

        public Comment(int createdBy) : this()
        {
            CreatedBy = createdBy;
        }

        public string Description { get; set; }
    }
}
