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

        
        /// <summary>
        /// Gives the index page
        /// </summary>
        /// <returns>The home index page</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// HttpGet which gives the blank request form
        /// </summary>
        /// <returns>The blank request form</returns>
        [HttpGet]
        public ActionResult RequestForm()
        {
            return View();
        }

        /// <summary>
        /// HttpPost which adds an entry into the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>If successful, moves to the ViewRequests page, 
        /// else gives a view of the form which was unsuccessful</returns>
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

        /// <summary>
        /// Deletes an entry from the database
        /// </summary>
        /// <param name="id"> The id of the entry to be deleted </param>
        /// <returns>Returns to the index view</returns>
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

        /// <summary>
        /// Returns a veiw of the database entries
        /// </summary>
        /// <returns>Returns a view of the database entries</returns>
        public ActionResult ViewRequests()
        {
            Debug.WriteLine(db.Users);
            return View(db.Users.ToList());
        }
    }
}