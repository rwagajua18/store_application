using System.Collections.Generic;
using store_application.API.models;

namespace app.API.IRepositories
{
    public interface ICategoryRepo
    {
        //get all categories
        //get products in a particular category
        
        IEnumerable<Category> Get();

        IEnumerable<Category> GetProductsFromCategory(int id);
         
    }
}