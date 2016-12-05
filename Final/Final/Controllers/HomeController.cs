using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class HomeController : Controller
    {

        private Model db = new Model();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestList()
        {
            return View(db.TestTables);
        }
    }
}