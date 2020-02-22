using ProductManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repositories
{
    public interface ICategoryRepository
    {
        #region "Methods"
        List<Category> GetCategories();        
        void AddCategory(Category category);
        void DeleteCategory(int categoryid);
        #endregion
    }
}
