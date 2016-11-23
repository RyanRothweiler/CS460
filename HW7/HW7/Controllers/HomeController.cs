using HW7.Models;
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

        private Model1 db = new Model1();

        // GET: Home
        public ActionResult Index()
        {
            //ViewBag.csvRows = new string[] { " \" Date,Temperature \" \n + ", "2008-05-07,75 \n", "2008-05-08,70 \n", "2008-05-09,80 \n" };

            return View();
        }

        public JsonResult GetStockData()
        {
            string stockSymbol = "no such symbol";
            stockSymbol = Request.QueryString["sym"];

            string responseText = String.Empty;

            string[,] dataArray = new string[100, 100];
            int x = 0;
            int y = 0;

            string[] DateCol = new string[50];
            string[] OpenCol = new string[50];
            string[] HighCol = new string[50];
            string[] LowCol = new string[50];
            string[] CloseCol = new string[50];

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://chart.finance.yahoo.com/table.csv?s=" + stockSymbol + "&a=9&b=16&c=2016&d=10&e=16&f=2016&g=d&ignore=.csv");
            request.Method = "GET";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    responseText = sr.ReadToEnd();
                }

                string[] dataRows = responseText.Split('\n');
                for (int index = 0; index < dataRows.Length; index++)
                {
                    string[] cells = dataRows[index].Split(',');

                    for (int cellIndex = 0; cellIndex < cells.Length; cellIndex++)
                    {
                        // date
                        if (cellIndex == 0)
                        { 
                            DateCol[x] += cells[cellIndex];
                        }
                        // open
                        else if (cellIndex == 1)
                        {
                            if (index == 0)
                            {
                                OpenCol[x] = stockSymbol + "-";
                            }
                            OpenCol[x] += cells[cellIndex];
                        }
                        // high 
                        else if (cellIndex == 2)
                        {
                            if (index == 0)
                            {
                                HighCol[x] = stockSymbol + "-";
                            }
                            HighCol[x] += cells[cellIndex];
                        }
                        // low
                        else if (cellIndex == 3)
                        {
                            if (index == 0)
                            {
                                LowCol[x] = stockSymbol + "-";
                            }
                            LowCol[x] += cells[cellIndex];
                        }
                        // Close
                        else if (cellIndex == 4)
                        {
                            if (index == 0)
                            {
                                CloseCol[x] = stockSymbol + "-";
                            }
                            CloseCol[x] += cells[cellIndex];
                        }
                    }

                    x++;
                }
            }
            catch (Exception e)
            {
                stockSymbol = "No such symbol.";
            }



            var data = new
            {
                symbol = stockSymbol,
                graphNum = Request.QueryString["graphNum"],

                date = DateCol,
                open = OpenCol,
                low = LowCol,
                close = CloseCol,
                high = HighCol,

            };

            Request newRequest = new Models.Request();
            newRequest.RequestType = Request.RawUrl;
            newRequest.SourceIP = Request.UserHostAddress;
            newRequest.BrowserType = Request.QueryString["browser"];
            newRequest.Date = DateTime.Now;
            db.Requests.Add(newRequest);
            db.SaveChanges();


            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}