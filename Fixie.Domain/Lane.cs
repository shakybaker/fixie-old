using System;
using System.Collections.Generic;
using Fixie.Domain.Enumerators;

namespace Fixie.Domain
{
    public class Lane :  IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }

        public Lane()
        {
            Cards = new List<Card>();
        }

        public Lane(int createdBy) : this()
        {
            CreatedBy = createdBy;
        }

        public int Sequence { get; set; }
        public string Name { get; set; }
        public IList<Card> Cards { get; set; }
    }
}
