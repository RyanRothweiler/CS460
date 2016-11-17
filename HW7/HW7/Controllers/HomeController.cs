using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            string stockSymbol = Request.QueryString["sym"];
            string responseText = String.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://chart.finance.yahoo.com/table.csv?s=" + stockSymbol + "&a=9&b=16&c=2016&d=10&e=16&f=2016&g=d&ignore=.csv");
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://finance.yahoo.com/d/quotes.csv?s=" + stockSymbol + "&f=o");
            request.Method = "GET";
            try
            {


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    responseText = sr.ReadToEnd();
                }


            }
            catch (Exception e)
            {
                stockSymbol = "No such symbol.";
            }

            var data = new
            {
                symbol = stockSymbol,
                yahooFile = responseText,
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}