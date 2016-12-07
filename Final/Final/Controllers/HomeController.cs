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

        /// <summary>
        /// Initial homepage http get
        /// </summary>
        /// <returns>Index home page view</returns>
        public ActionResult Index()
        {
            ViewBag.genreNames = db.Genres.Select(g => g.Name);
            return View();
        }

        /// <summary>
        /// Creates a json object holding aggregated data. The obj holds a list which holds the name of
        /// artist and the title of their art if that art is under the given genre
        /// </summary>
        /// <returns>Json object which holds genre data</returns>
        public JsonResult GetGenreData()
        {
            string genreWanting = Request.QueryString["g"];

            var dbData = from g in db.Genres
                         where g.Name == genreWanting
                         join c in db.Classifications on g.ID equals c.GenreID
                         join aw in db.Artworks on c.ArtworkID equals aw.ID
                         join a in db.Artists on aw.ArtistID equals a.ID
                         select new { ArtworkTitle = aw.Title, ArtistName = a.Name };

            var data = new
            {
                artworksCount = dbData.Count(),
                artworks = dbData,
            };

            return Json(data, JsonRequestBehavior.AllowGet);
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

        /// <summary>
        /// Initial http get for the artists creation page
        /// </summary>
        /// <returns>Artist creation view</returns>
        public ActionResult ArtistCreate()
        {
            return View();
        }

        /// <summary>
        /// Adds an artist to the db
        /// </summary>
        /// <param name="newArtist">The artist to add to the db</param>
        /// <returns>The artist list view</returns>
        [HttpPost]
        public ActionResult ArtistCreate(Artist newArtist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(newArtist);
                db.SaveChanges();

                return RedirectToAction("ArtistsList");
            }

            return View();
        }

        /// <summary>
        /// Http get for artist details page
        /// </summary>
        /// <param name="id">The id of the artist showing details for</param>
        /// <returns>The artist details view</returns>
        public ActionResult ArtistDetails(int id)
        {
            return View(db.Artists.Find(id));
        }

        /// <summary>
        /// Http get for artists edit page
        /// </summary>
        /// <param name="id">The id of the artist who is being edited</param>
        /// <returns>The artist details page and the artist editing model</returns>
        public ActionResult ArtistEdit(int id)
        {
            return View(db.Artists.Find(id));
        }

        /// <summary>
        /// Http post for artists edit page. Saves the changes to the database
        /// </summary>
        /// <param name="id">The id of the artist editing</param>
        /// <param name="form">Used to separate from http get ArtistEdit</param>
        /// <returns>
        /// If successfull returns to the artist list, otherwise returns to the artists edit page
        /// and gives the artist model
        /// </returns>
        [HttpPost]
        public ActionResult ArtistEdit(int? id, FormCollection form)
        {
            Artist artistToUpdate = db.Artists.Find(id);
            TryUpdateModel(artistToUpdate, "", new string[] { "Name", "BirthDate", "BirthCity" });

            if (ModelState.IsValid)
            {    
                db.SaveChanges();
                return RedirectToAction("ArtistsList");
            }

            return View(db.Artists.Find(id));
        }

        /// <summary>
        /// Http get to delete an artist
        /// </summary>
        /// <param name="id">The id of the artist deleting</param>
        /// <returns>The view for the artists list</returns>
        public ActionResult ArtistDelete(int? id)
        {
            db.Artists.Remove(db.Artists.Find(id));
            db.SaveChanges();
            return RedirectToAction("ArtistsList");
        }
    }
}