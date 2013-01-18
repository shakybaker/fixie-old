using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Fixie.Domain;
using Fixie.Models;

namespace Fixie.Controllers
{
    public class CardApiController : ApiController
    {
        private FixieContext db = new FixieContext();

        // GET api/CardApi
        public IEnumerable<Card> GetCards()
        {
            return db.Cards.AsEnumerable();
        }

        // GET api/CardApi/5
        public Card GetCard(int id)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return card;
        }

        // PUT api/CardApi/5
        public HttpResponseMessage PutCard(int id, Card card)
        {
            if (ModelState.IsValid && id == card.Id)
            {
                db.Entry(card).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/CardApi
        public HttpResponseMessage PostCard(Card card)
        {
            if (ModelState.IsValid)
            {
                db.Cards.Add(card);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, card);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = card.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/CardApi/5
        public HttpResponseMessage DeleteCard(int id)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Cards.Remove(card);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, card);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}