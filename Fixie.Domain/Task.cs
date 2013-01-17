using System;

namespace Fixie.Domain
{
    public class Task : IEntity
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public int ModifiedBy { get; set; }

        public Task()
        {
        }

        public Task(int createdBy)
            : this()
        {
            CreatedBy = createdBy;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
