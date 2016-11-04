using HW6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class CategoryHolder
    {
        public String categoryName;
        public List<String> subCategories = new List<String>();
    }


    public class HomeController : Controller
    {
        private ProductionModel prodModel = new ProductionModel();

        // GET: Home
        public ActionResult Index()
        {
            List<CategoryHolder> catHolder = new List<CategoryHolder>();
            foreach (ProductCategory category in prodModel.ProductCategories)
            {
                CategoryHolder newHolder = new CategoryHolder();
                newHolder.categoryName = category.Name;

                foreach (ProductSubcategory subCat in category.ProductSubcategories)
                {
                    newHolder.subCategories.Add(subCat.Name);
                }

                catHolder.Add(newHolder);
            }

            ViewBag.categories = catHolder;
            return View();
        }
    }
}