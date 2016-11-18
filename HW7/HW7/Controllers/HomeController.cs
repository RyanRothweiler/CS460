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

            string[,] dataArray = new string[100, 100];
            int x = 0;
            int y = 0;
            int colCount = 0;

            string[] DateCol = new string[50];
            string[] OpenCol = new string[50];
            string[] HighCol = new string[50];
            string[] LowCol = new string[50];
            string[] CloseCol = new string[50];

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

                string[] dataRows = responseText.Split('\n');
                for (int index = 0; index < dataRows.Length; index++)
                {
                    string[] cells = dataRows[index].Split(',');

                    for (int cellIndex = 0; cellIndex < cells.Length; cellIndex++)
                    {
                        // date
                        if (cellIndex == 0)
                        {
                            DateCol[x] = cells[cellIndex];
                        }
                        // open
                        else if (cellIndex == 1)
                        {
                            OpenCol[x] = cells[cellIndex];
                        }
                        // high 
                        else if (cellIndex == 2)
                        {
                            HighCol[x] = cells[cellIndex];
                        }
                        // low
                        else if (cellIndex == 3)
                        {
                            LowCol[x] = cells[cellIndex];
                        }
                        // Close
                        else if (cellIndex == 4)
                        {
                            CloseCol[x] = cells[cellIndex];
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

                date = DateCol,
                open = OpenCol,
                low = LowCol,
                close = CloseCol,
                high = HighCol,
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}