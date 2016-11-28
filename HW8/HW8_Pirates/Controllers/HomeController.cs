using HW8_Pirates.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8_Pirates.Controllers
{
    public class HomeController : Controller
    {
        private Model db = new Model();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrewView()
        {
            return View(db.Crews);
        }

        public ActionResult ShipsView()
        {
            return View(db.Ships);
        }

        public ActionResult PiratesView()
        {
            return View(db.Pirates);
        }

        public ActionResult CreatePirate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePirate(Pirate newPirate)
        {
            // TODO make sure that the date is in the past

            if (ModelState.IsValid)
            {
                db.Pirates.Add(newPirate);
                db.SaveChanges();

                return RedirectToAction("PiratesView");
            }
  
            return View(newPirate);
        }

        public ActionResult ReadPirate(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("PiratesView");
            }

            Pirate pirate = db.Pirates.Find(id);
            if (pirate == null)
            {
                return RedirectToAction("PiratesView");
            }

            return View(pirate);
        }

        public ActionResult UpdatePirate(int? id)
        {
            Pirate pir = db.Pirates.Find(id);
            return View(pir);
        }

        [HttpPost]
        public ActionResult UpdatePirate(int? id, FormCollection form)
        {
            Pirate pirateToUpdate = db.Pirates.Find(id);
            TryUpdateModel(pirateToUpdate, "", new string[] { "Name", "Date"});
            db.SaveChanges();
            return RedirectToAction("PiratesView");
        }

        public ActionResult DeletePirate(int? id)
        {
            Pirate pirateToDelete = db.Pirates.Find(id);
            db.Pirates.Remove(pirateToDelete);
            db.SaveChanges();

            return RedirectToAction("PiratesView");
        }
    }
}