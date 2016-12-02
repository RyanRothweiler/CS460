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

        public ActionResult PiratesView(string button)
        {
            int page = 0;
            if (button != null) 
            {
                page = int.Parse(button);
            }
            int pageSize = 3;

            ViewBag.PagesCount = GetPiratePagesCount(pageSize);

            var piratesList = (from p in db.Pirates
                               orderby p.ID
                               select p).Skip(pageSize * (int)page).Take(pageSize).ToList();
            //var piratesList = db.Pirates.OrderBy().Skip(pageSize * (int)page).Take(pageSize).ToList();
            return View(piratesList);
        }
          
        public int GetPiratePagesCount(int pageSize)
        {
            float pageCount = (float)db.Pirates.ToList().Count / (float)pageSize;
            if ((int)pageCount < pageCount)
            {
                return ((int)(pageCount + 1));
            }
            return ((int)pageCount);
        }

        public ActionResult CreatePirate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePirate(Pirate newPirate)
        {
            if (ModelState.IsValid && newPirate.DateConscripted < DateTime.Now)
            {
                db.Pirates.Add(newPirate);
                db.SaveChanges();

                return RedirectToAction("PiratesView");
            }
  
            return View(newPirate);
        }

        public JsonResult GetBooty()
        {

            var bootyList = db.Pirates.Select(p => new {Name = p.Name, Booty = p.Crews.Select(c => c.Booty).Sum()})
                .OrderByDescending(pnb => pnb.Booty);

            var data = new
            {
                bootyVal = bootyList,
                bootySize = bootyList.Count(),
            };

            return Json(data, JsonRequestBehavior.AllowGet);
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
            DateTime testDate = DateTime.Parse(form["DateConscripted"]);
            if (testDate < DateTime.Now)
            {
                Pirate pirateToUpdate = db.Pirates.Find(id);
                TryUpdateModel(pirateToUpdate, "", new string[] { "Name", "DateConscripted" });
                db.SaveChanges();
                return RedirectToAction("PiratesView");
            }
            else
            {
                return (View(db.Pirates.Find(id)));
            }
        }

        public ActionResult DeletePirate(int? id)
        {
            var crewsToDelete = db.Crews.Where(c => c.PirateID == id);
            foreach (Crew c in crewsToDelete)
            {
                db.Crews.Remove(c);
            }

            Pirate pirateToDelete = db.Pirates.Find(id);
            db.Pirates.Remove(pirateToDelete);

            db.SaveChanges();

            return RedirectToAction("PiratesView");
        }
    }
}