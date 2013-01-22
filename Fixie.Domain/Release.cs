using System;
using System.Collections.Generic;

namespace Fixie.Domain
{
    public class Release : IEntity
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public int ModifiedBy { get; set; }

        public Release()
        {
            Boards = new List<Board>();
        }

        public Release(int createdBy)
            : this()
        {
            CreatedBy = createdBy;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Board> Boards { get; set; }
    }
}
