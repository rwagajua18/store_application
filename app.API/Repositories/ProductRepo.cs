using System.Collections.Generic;
using app.API.IRepositories;
using store_application.API.models;
using store_application.API.models.Data;
using System.Linq;

namespace app.API.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly StoreContext _context;
        public ProductRepo(StoreContext context)
        {
            _context = context;
            
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(product);
        }

        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();

        }

        public Product getByProductId(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }
    }
}