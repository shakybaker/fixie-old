using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fixie.Domain;
using Fixie.Models;

namespace Fixie.Controllers
{   
    public class BoardsController : Controller
    {
		private readonly IBoardRepository boardRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public BoardsController() : this(new BoardRepository())
        {
        }

        public BoardsController(IBoardRepository boardRepository)
        {
			this.boardRepository = boardRepository;
        }

        //
        // GET: /Boards/

        public ViewResult Index()
        {
            return View(boardRepository.AllIncluding(board => board.Lanes));
        }

        //
        // GET: /Boards/Details/5

        public ViewResult Details(int id)
        {
            return View(boardRepository.Find(id));
        }

        //
        // GET: /Boards/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Boards/Create

        [HttpPost]
        public ActionResult Create(Board board)
        {
            if (ModelState.IsValid) {
                boardRepository.InsertOrUpdate(board);
                boardRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Boards/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(boardRepository.Find(id));
        }

        //
        // POST: /Boards/Edit/5

        [HttpPost]
        public ActionResult Edit(Board board)
        {
            if (ModelState.IsValid) {
                boardRepository.InsertOrUpdate(board);
                boardRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Boards/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(boardRepository.Find(id));
        }

        //
        // POST: /Boards/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            boardRepository.Delete(id);
            boardRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                boardRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

