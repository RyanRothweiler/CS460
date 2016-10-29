using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW5_MajorMinorForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestForm()
        {
            return View();
        }

        public ActionResult ViewRequests()
        {
            return View();
        }
    }
}