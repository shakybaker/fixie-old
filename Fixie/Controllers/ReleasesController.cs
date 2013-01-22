using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fixie.Domain;
using Fixie.Models;

namespace Fixie.Controllers
{   
    public class ReleasesController : Controller
    {
        private FixieWebContext context = new FixieWebContext();

        //
        // GET: /Releases/

        public ViewResult Index()
        {
            return View(context.Releases.Include(release => release.Boards).ToList());
        }

        //
        // GET: /Releases/Details/5

        public ViewResult Details(int id)
        {
            Release release = context.Releases.Single(x => x.Id == id);
            return View(release);
        }

        //
        // GET: /Releases/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Releases/Create

        [HttpPost]
        public ActionResult Create(Release release)
        {
            if (ModelState.IsValid)
            {
                context.Releases.Add(release);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(release);
        }
        
        //
        // GET: /Releases/Edit/5
 
        public ActionResult Edit(int id)
        {
            Release release = context.Releases.Single(x => x.Id == id);
            return View(release);
        }

        //
        // POST: /Releases/Edit/5

        [HttpPost]
        public ActionResult Edit(Release release)
        {
            if (ModelState.IsValid)
            {
                context.Entry(release).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(release);
        }

        //
        // GET: /Releases/Delete/5
 
        public ActionResult Delete(int id)
        {
            Release release = context.Releases.Single(x => x.Id == id);
            return View(release);
        }

        //
        // POST: /Releases/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Release release = context.Releases.Single(x => x.Id == id);
            context.Releases.Remove(release);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}