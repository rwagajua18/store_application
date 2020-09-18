using System.Collections.Generic;
using System.Linq;
using app.API.IRepositories;
using app.API.models;
using Microsoft.EntityFrameworkCore;
using store_application.API.models;
using store_application.API.models.Data;

namespace app.API.Repositories
{
    /// <summary>
    /// store repository
    /// </summary>
    public class StoreRepository:IStoreRepository
    {
        private readonly StoreContext _context;
        public StoreRepository(StoreContext context)
        {
            _context = context;

        }

        /// <summary>
        /// gets products from the store
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a list of products</returns>

        public IEnumerable<Store> getProductsFromStore(int id)
        {
            var products = _context.Stores
                           .Include(i => i.Inventory)
                           .ThenInclude(p => p.Product)
                           .Where(s => s.StoreId == id).ToList();

            return products;
        }

        /// <summary>
        /// gets all stores
        /// </summary>
        /// <returns>a list of stores</returns>
        public IEnumerable<Store> getStores()
        {
            return _context.Stores.ToList();
        }
        
        /// <summary>
        /// returns a list of products from a store by its name.
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="productName"></param>
        /// <returns>list of products</returns>
        public IEnumerable<Store> getProductFromStore(string storeName, string productName)
        {
            var product = _context.Stores
                          .Include(i => i.Inventory)
                          .ThenInclude(p => p.Product)
                          .Where(s => s.StoreName == storeName && s.Inventory.Product.Name == productName).ToList();

            return product;
        }
    }
}