using HW6.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6.Controllers
{


/// <summary>
/// Convenience class to organize the category and subcategories in a way easy to display
/// </summary>
public class CategoryHolder
{
    public String categoryName;
    public List<String> subCategories = new List<String>();
}


public class HomeController : Controller
{

    private ProductionModel prodModel = new ProductionModel();

    /// <summary>
    /// Initial homepage
    /// </summary>
    /// <returns></returns>
    public ActionResult Index()
    {
        ViewBag.categories = BuildCategories();
        return View();
    }

    /// <summary>
    /// Post method for main page. Called after a sub category button was clicked.
    /// </summary>
    /// <param name="button">Holds the name of the sub category button which was clicked.</param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult Index(string button)
    {
        List<Product> allProducts = new List<Product>();
        foreach (Product prod in prodModel.Products)
        {
            if (prod.ProductSubcategory != null &&
                prod.ProductSubcategory.Name == button)
            {
                allProducts.Add(prod);
            }
        }

        if (allProducts.Count == 0)
        {
            foreach (Product prod in prodModel.Products)
            {
                if (prod.Name == button)
                {
                    ViewBag.product = prod;
                    return View("ProductReviews", prod.ProductReviews);
                }
            }

            return View("Index");
        }
        else
        {
            ViewBag.products = allProducts;
            return View("ProductsView");
        }
    }

    /// <summary>
    /// Returns a list of the category and sub category options.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Giving a review page for a product
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public ActionResult ProductReviews()
    {
        return View();
    }

    /// <summary>
    /// Giving initial review form page
    /// </summary>
    /// <returns></returns>
    public ActionResult AddReview()
    {
        return View(new ProductReview());
    }

    /// <summary>
    /// Adds a review to the database
    /// </summary>
    /// <param name="review">The review to add</param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult AddReview(ProductReview review)
    {
        if (ModelState.IsValid)
        {
            review.ModifiedDate = DateTime.Now;
            foreach (Product prod in prodModel.Products)
            {
                if (prod.ProductID == review.ProductID)
                {
                    review.Product = prod;
                    prod.ProductReviews.Add(review);
                    break;
                }
            }

            prodModel.SaveChanges();

        }

        ViewBag.categories = BuildCategories();
        return RedirectToAction("Index");
    }
}
}