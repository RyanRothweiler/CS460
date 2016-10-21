using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PageOne()
        {
            string[] data = {Request.RawUrl};
            ViewBag.data = data;
            return (View());
        }

        [HttpPost]
        public ActionResult PageOne(FormCollection form)
        {
            string[] data = {Request.RawUrl};
            ViewBag.data = data;
            return (View());
        }
    }
}