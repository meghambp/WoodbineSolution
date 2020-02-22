using ProductManagement.Data;
using ProductManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        public IProductRepository ProductRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
        }
        public ActionResult ProductsList(string sortOrder, string currentFilter, string searchString, int? page)
        {            
            try
            {
                ViewBag.CurrentSort = sortOrder;

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                List<Product> lstProducts = new List<Product>();
                if (searchString != null && searchString != "")
                {
                    lstProducts = ProductRepository.GetProducts(searchString);
                }
                else
                {
                    lstProducts = ProductRepository.GetProducts();
                }
                return View(lstProducts.ToPagedList(page ?? 1, 3));
            }
            catch (Exception Ex)
            {
                //Log the error 
                //ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return View("Error");
            }
        }
        public ActionResult AddProduct()
        {           
            ViewBag.CategoryList = new SelectList(CategoryRepository.GetCategories(), "CategoryID", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct([Bind(Include = "ProductName, Description, UnitPrice,CategoryID")]Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.CategoryList = new SelectList(CategoryRepository.GetCategories(), "CategoryID", "CategoryName");
                    return View();
                }
                ProductRepository.AddProduct(product);  
            }
            catch (Exception Ex)
            {
                //Log the error 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return View("Error");
            }
            return RedirectToAction("ProductsList");
        }      
        public ActionResult DeleteProduct(int productid)
        {
            try
            {
                ProductRepository.DeleteProduct(productid);                
            }
            catch (Exception ex)
            {
                //Log the error 
                ModelState.AddModelError("", "Unable to delete. Try again, and if the problem persists see your system administrator.");
                return View("Error");
            }
            return RedirectToAction("ProductsList");
        }
    }
}