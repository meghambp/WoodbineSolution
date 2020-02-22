using ProductManagement.Data;
using ProductManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class ProductModel : IProductRepository
    {
        WoodbineTestConnection dc = new WoodbineTestConnection();

        public void AddProduct(Product product)
        {
            dc.Products.Add(product);
            dc.SaveChanges();
        }

        public void DeleteProduct(int productid)
        {
            Product product = dc.Products.Find(productid);
            dc.Products.Remove(product);
            dc.SaveChanges();
        }
       
        public List<Product> GetProducts()
        {
            List<Product> _prds = dc.Products.ToList();
            if (_prds != null)
            {
                return _prds;
            }
            return null;
        }

        public List<Product> GetProducts(string search)
        {
            List<Product> _prds = dc.Products.Where(p => (p.ProductName.Contains(search) || p.Description.Contains(search))).ToList();
            if (_prds != null)
            {
                return _prds;
            }
            return null;
        }
       
    }
}