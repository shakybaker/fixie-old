using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using Fixie.Domain;
using Fixie.Models;

namespace Fixie.Code.Repository
{
    public class CardRepository : ICardRepository
    {
        private FixieContext db = new FixieContext();

        public IEnumerable<Card> GetAll()
        {
            return db.Cards.AsEnumerable();
        }

        public Card Get(int id)
        {
            var card = db.Cards.Find(id);
            if (card == null)
            {
                //throw
            }

            return card;
        }

        public Card Add(Card card)
        {
            db.Cards.Add(card);
            db.SaveChanges();

            return card;
        }

        public void Remove(int id)
        {
            var card = db.Cards.Find(id);
            db.Cards.Remove(card);
            db.SaveChanges();
        }

        public bool Update(Card card)
        {
            db.Entry(card).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }
    }
}