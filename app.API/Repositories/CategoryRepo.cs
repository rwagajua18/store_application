using System.Collections.Generic;
using app.API.IRepositories;
using store_application.API.models;
using store_application.API.models.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace app.API.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly StoreContext _context;

        public CategoryRepo(StoreContext context)
        {
            _context = context;
            
        }
        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Category> GetProductsFromCategory(int id)
        {
            var products = _context.Categories
                           .Include(p => p.Products).Where(x => x.catID == id).ToList();

            return products;
        }
    }
}