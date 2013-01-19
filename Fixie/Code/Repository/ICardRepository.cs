using System.Collections.Generic;
using Fixie.Domain;

namespace Fixie.Code.Repository
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAll();
        Card Get(int id);
        Card Add(Card item);
        void Remove(int id);
        bool Update(Card item);
    }
}