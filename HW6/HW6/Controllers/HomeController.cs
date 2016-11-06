using HW6.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            Debug.WriteLine("Doing Get");

            ViewBag.categories = BuildCategories();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string button)
        {
            Debug.WriteLine("Doing Post for " + button);

            if (button == "addreview")
            {
                Debug.WriteLine("Going to review form");
            }

            List<Product> allProducts = new List<Product>();
            foreach (Product prod in prodModel.Products)
            {
                if (prod.ProductSubcategory != null && 
                    prod.ProductSubcategory.Name == button)
                {
                    Debug.WriteLine(prod.ProductSubcategory.Name);
                    allProducts.Add(prod);
                }
            }

            if (allProducts.Count == 0)
            {
                Debug.WriteLine("Go to review page for " + button);

                foreach (Product prod in prodModel.Products)
                {
                    if (prod.Name == button)
                    {
                        Debug.WriteLine("Going to product view");
                        ViewBag.product = prod;
                        return View("ProductReviews", prod.ProductReviews);
                    }
                }

                Debug.WriteLine("Could not find that product.");
                return View("Index");
            }
            else
            {
                ViewBag.products = allProducts;
                return View("ProductsView");
            }
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

        public ActionResult ProductsView()
        {
            return View("Index");
        }

        public ActionResult ProductReviews()
        {
            Debug.WriteLine("Product reviews GET");

            return View();
        }

        [HttpPost]
        public ActionResult ProductReviews(string button)
        {
            Debug.WriteLine("Add new review to database");

            ViewBag.categories = BuildCategories();
            return View();
        }

        public ActionResult AddReview()
        {
            return View(new ProductReview());
        }

        [HttpPost]
        public ActionResult AddReview(ProductReview review)
        {
            Debug.WriteLine("Adding Review");

            if (ModelState.IsValid)
            {
                Debug.WriteLine("Adding Review for " + review.ProductID);
                foreach (Product prod in prodModel.Products)
                {
                    if (prod.ProductID == review.ProductID)
                    {
                        review.Product = prod;
                        prod.ProductReviews.Add(review);
                        prodModel.SaveChanges();
                        Debug.WriteLine("ADDED REVIEW");
                        return View("Index");
                        break;
                    }
                }

                for (int index = 0; index < prodModel.Products.Count<Product>(); index++)
                {
                    //if (prodModel.Products[index].ProductID == review.ProductID)
                    {

                    }
                }
            }

            return View(review);
        }
    }
}