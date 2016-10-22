using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;


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
            ViewBag.Rows = 0;
            ViewBag.Columns = 0;

            return (View());
        }

        [HttpPost]
        public ActionResult PageOne(FormCollection form)
        {
            NameValueCollection pairs = Request.Form;
            ViewBag.Rows = int.Parse(pairs["Rows"]);
            ViewBag.Columns = int.Parse(pairs["Columns"]);

            return (View());
        }

        [HttpGet]
        public ActionResult PageTwo()
        {
            ViewBag.BarValue = 0;
            string inputVal = Request.QueryString["Value"];
            if (inputVal != null)
            {
                ViewBag.BarValue = int.Parse(inputVal);
            }

            if (ViewBag.BarValue < 0)
            {
                ViewBag.BarValue = 0;
            }
            if (ViewBag.BarValue > 100)
            {
                ViewBag.BarValue = 100;
            }

            return (View());
        }

        public ActionResult PageThree()
        {
            return (View());
        }
    }
}