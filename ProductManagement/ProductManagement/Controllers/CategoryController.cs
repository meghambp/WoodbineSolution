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
    public class CategoryController : Controller
    {
        public ICategoryRepository CategoryRepository { get; private set; }

        public CategoryController(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }
        public ActionResult CategoryList(int? page)
        {
            try
            {
                List<Category> lstcategories = new List<Category>();

                lstcategories = CategoryRepository.GetCategories();
                return View(lstcategories.ToPagedList(page ?? 1, 10));
            }
            catch (Exception Ex)
            {
                //Log the error 
                //ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return View("Error");
            }
        }
        public ActionResult AddCategory()
        {
             return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory([Bind(Include = "CategoryName, Description")]Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                CategoryRepository.AddCategory(category);
            }
            catch (Exception Ex)
            {
                //Log the error 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return View("Error");
            }
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int categoryid)
        {
            try
            {
                CategoryRepository.DeleteCategory(categoryid);
            }
            catch (Exception ex)
            {
                //Log the error 
                // We can't delete referenced category so can handle error here
                ModelState.AddModelError("", "Unable to delete. Try again, and if the problem persists see your system administrator.");
                return View("Error");
            }
            return RedirectToAction("CategoryList");
        }
    }
}