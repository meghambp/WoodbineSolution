using ProductManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repositories
{
    public interface IProductRepository
    {
        #region "Methods"
        List<Product> GetProducts();
        List<Product> GetProducts(string search);
        void AddProduct(Product product);
        void DeleteProduct(int productid);
        #endregion
    }
}
