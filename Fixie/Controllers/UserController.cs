using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Fixie.Domain;
using Fixie.Models;

namespace Fixie.Controllers
{   
    public class UserController : Controller
    {
        private FixieWebContext context = new FixieWebContext();

        //


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = context.Users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), user.RememberMe);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: /User/

        public ViewResult Index()
        {
            return View(context.Users.ToList());
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(int id)
        {
            User user = context.Users.Single(x => x.Id == id);
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            //TODO: check email deosnt exist already
            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();
                
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /User/Signup

        public ActionResult Signup()
        {
            return View();
        }

        //
        // POST: /User/Signup

        [HttpPost]
        public ActionResult Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password, //TODO: Hash this
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                };
                context.Users.Add(user);
                context.SaveChanges();

                var newUser = context.Users.SingleOrDefault(x => x.Email == user.Email && x.Password == model.Password);
                if (newUser != null) FormsAuthentication.SetAuthCookie(newUser.Id.ToString(), user.RememberMe);

                return RedirectToAction("Index", "Dashboard");
            }

            return View(model);
        }

        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
        {
            User user = context.Users.Single(x => x.Id == id);
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(int id)
        {
            User user = context.Users.Single(x => x.Id == id);
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = context.Users.Single(x => x.Id == id);
            context.Users.Remove(user);
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