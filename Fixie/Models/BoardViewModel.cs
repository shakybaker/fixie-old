using System.Collections.Generic;
using Fixie.Domain;

namespace Fixie.Models
{
    public class BoardViewModel
    {
        public BoardViewModel()
        {
            Board = new Board();
        }

        public Board Board { get; set; }
    }
}