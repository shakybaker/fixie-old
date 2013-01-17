using System;
using System.Collections.Generic;
using Fixie.Domain.Enumerators;

namespace Fixie.Domain
{
    public class Lane
    {
        public Lane()
        {
            Cards = new List<Card>();
        }

        public int Id { get; set; }
        public int Sequence { get; set; }
        public string Name { get; set; }
        public IList<Card> Cards { get; set; }
    }
}
