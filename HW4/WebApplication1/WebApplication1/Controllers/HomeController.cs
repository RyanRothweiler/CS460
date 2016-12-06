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
        /// <summary>
        /// Get for index home page
        /// </summary>
        /// <returns>View of index home page</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Initial get for page one
        /// </summary>
        /// <returns>View for page one</returns>
        [HttpGet]
        public ActionResult PageOne()
        {
            ViewBag.Rows = 0;
            ViewBag.Columns = 0;

            return (View());
        }

        /// <summary>
        /// Post for the table builder page. 
        /// </summary>
        /// <param name="form">Used to differentiate with httpget for page one</param>
        /// <returns>View for page one with information in viewbag</returns>
        [HttpPost]
        public ActionResult PageOne(FormCollection form)
        {
            NameValueCollection pairs = Request.Form;
            ViewBag.Rows = int.Parse(pairs["Rows"]);
            ViewBag.Columns = int.Parse(pairs["Columns"]);

            return (View());
        }

        /// <summary>
        /// Initial get for progress bar builder page
        /// </summary>
        /// <returns>View of progress bar page</returns>
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

        /// <summary>
        /// Initial get for loan calculator page
        /// </summary>
        /// <returns>Loan calculator page</returns>
        [HttpGet]
        public ActionResult PageThree()
        {
            return (View());
        }

        /// <summary>
        /// Builds information for loan calculator page
        /// </summary>
        /// <param name="LoanAmount">The loan amount</param>
        /// <param name="InterestRate">The interest rate</param>
        /// <param name="TermLength">The term length</param>
        /// <returns>Loan calculator page</returns>
        [HttpPost]
        public ActionResult PageThree(double? LoanAmount, double? InterestRate, double? TermLength)
        {
            if (LoanAmount == null || InterestRate == null || TermLength == null)
            {
                ViewBag.Valid = false;
            }
            else
            {
                ViewBag.Valid = true;
           
                double payment = (LoanAmount.Value * (InterestRate.Value / -100.0)) / (1 - Math.Pow((1 + (InterestRate.Value / 100.0)), TermLength.Value));
                ViewBag.Payment = payment;
            }
            return (View());
        }
    }
}