using System;
using System.Collections.Generic;
using Fixie.Domain.Enumerators;

namespace Fixie.Domain
{
    public class Board : IEntity
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public int ModifiedBy { get; set; }

        public Board()
        {
            Type = BoardType.Board;
            Lanes = new List<Lane>();
        }

        public Board(int createdBy)
            : this()
        {
            CreatedBy = createdBy;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public BoardType Type { get; set; }
        public IList<Lane> Lanes { get; set; }
        public LaneTemplate LaneTemplate { get; set; }
        public PriorityLevelTemplate PriorityLevelTemplate { get; set; }
        public ComplexityLevelTemplate ComplexityLevelTemplate { get; set; }
    }
}
