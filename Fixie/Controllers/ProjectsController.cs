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
    public class ProjectsController : Controller
    {
        private FixieWebContext context = new FixieWebContext();

        //
        // GET: /Projects/

        public ViewResult Index()
        {
            return View(context.Projects.Include(project => project.Boards).ToList());
        }

        //
        // GET: /Projects/Details/5

        public ViewResult Details(int id)
        {
            Project project = context.Projects.Single(x => x.Id == id);
            return View(project);
        }

        //
        // GET: /Projects/Create

        public ActionResult Add()
        {
            return View("Create");
        } 

        //
        // POST: /Projects/Create

        [HttpPost]
        public ActionResult Add(Project project)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.Identity.Name);
                project.Created = DateTime.Now;
                project.CreatedBy = userId;
                project.Modified = DateTime.Now;
                project.ModifiedBy = userId;
                context.Projects.Add(project);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View("Create", project);
        }
        
        //
        // GET: /Projects/Edit/5
 
        public ActionResult Edit(int id)
        {
            Project project = context.Projects.Single(x => x.Id == id);
            return View(project);
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // GET: /Projects/Delete/5
 
        public ActionResult Delete(int id)
        {
            Project project = context.Projects.Single(x => x.Id == id);
            return View(project);
        }

        //
        // POST: /Projects/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = context.Projects.Single(x => x.Id == id);
            context.Projects.Remove(project);
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