using System.Collections.Generic;
using app.API.IRepositories;
using store_application.API.models;
using store_application.API.models.Data;
using System.Linq;

namespace app.API.Repositories
{
    /// <summary>
    /// product repository
    /// </summary>
    public class ProductRepo : IProductRepo
    {
        private readonly StoreContext _context;
        public ProductRepo(StoreContext context)
        {
            _context = context;
            
        }

        /// <summary>
        /// adds a product to the database.
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }


        /// <summary>
        /// saves changes to the database
        /// </summary>
        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// deletes a product from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProdId == id);
            _context.Products.Remove(product);
        }


        /// <summary>
        /// gets all products from the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();

        }

        /// <summary>
        /// gets a product by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product getByProductId(int id)
        {
            return _context.Products.FirstOrDefault(x => x.ProdId == id);
        }
    }
}