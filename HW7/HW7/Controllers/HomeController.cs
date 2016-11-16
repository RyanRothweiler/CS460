using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.csvRows = new string[] { " \" Date,Temperature \" \n + ", "2008-05-07,75 \n", "2008-05-08,70 \n", "2008-05-09,80 \n" };

            return View();
        }

        public JsonResult GetStockData()
        {
            var data = new
            {
                row = "Temp, Another"
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}