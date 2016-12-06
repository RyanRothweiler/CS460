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

        /// <summary>
        /// Initial http get for the artists lists
        /// </summary>
        /// <returns>Artists list view</returns>
        public ActionResult ArtistsList()
        {
            return View(db.Artists);
        }

        /// <summary>
        /// Initial http get for the artworks list
        /// </summary>
        /// <returns>Artworks list view</returns>
        public ActionResult ArtworksList()
        {
            return View(db.Artworks);
        }

        /// <summary>
        /// Initial http get for the classifications list
        /// </summary>
        /// <returns>Classifications list</returns>
        public ActionResult ClassificationsList()
        {
            return View(db.Classifications);
        }
    }
}