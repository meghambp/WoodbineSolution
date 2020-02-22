using ProductManagement.Data;
using ProductManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class CategoryModel : ICategoryRepository
    {
        WoodbineTestConnection dc = new WoodbineTestConnection();
        public List<Category> GetCategories()
        {           
            List<Category> _categories = dc.Categories.ToList();
            if (_categories != null)
            {
                return _categories;
            }
            return null;
        }
        public void AddCategory(Category category)
        {
            dc.Categories.Add(category);
            dc.SaveChanges();
        }

        public void DeleteCategory(int catid)
        {
            Category category = dc.Categories.Find(catid);
            dc.Categories.Remove(category);
            dc.SaveChanges();
        }              
    }
}