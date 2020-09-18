using System.Collections.Generic;
using app.API.IRepositories;
using store_application.API.models;
using store_application.API.models.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace app.API.Repositories
{
    /// <summary>
    /// category repository
    /// </summary>
    public class CategoryRepo : ICategoryRepo
    {
        /// <summary>
        /// Database constext field
        /// </summary>
        private readonly StoreContext _context;

        public CategoryRepo(StoreContext context)
        {
            _context = context;
            
        }
        /// <summary>
        /// gets all categories from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToList();
        }

        /// <summary>
        /// gets all products from a particular category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Category> GetProductsFromCategory(int id)
        {
            var products = _context.Categories
                           .Include(p => p.Products).Where(x => x.CategoryId == id).ToList();

            return products;
        }
    }
}