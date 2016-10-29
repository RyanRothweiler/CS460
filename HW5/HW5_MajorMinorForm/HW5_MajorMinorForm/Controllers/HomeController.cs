using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW5_MajorMinorForm.DAL;
using HW5_MajorMinorForm.Models;
using System.Diagnostics;

namespace HW5_MajorMinorForm.Controllers
{
    public class HomeController : Controller
    {

        private UserContext db = new UserContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RequestForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestForm(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("ViewRequests");
            }

            return View(user);
        }

        public ActionResult DeleteEntry(int? id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                Debug.WriteLine("Deleted");
            }
            return View("Index");
        }

        public ActionResult ViewRequests()
        {
            Debug.WriteLine(db.Users);
            return View(db.Users.ToList());
        }
    }
}