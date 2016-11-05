using HW6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ViewBag.categories = BuildCategories();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string inputString)
        {
            Debug.WriteLine("Doing this! " + inputString);
            /*
            List<Product> products = new List<Product>();
            foreach (Product prod in prodModel.Products)
            {
                if (prod.ProductSubcategory.Name == subCat)
                {
                    Debug.WriteLine(prod.ProductSubcategory.Name);
                    products.Add(prod);
                }
            }

            ViewBag.products = products;
            return RedirectToAction("ProductsView");
            */

            return View();
        }

        public List<CategoryHolder> BuildCategories()
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
            return (catHolder);
        }
    }
}