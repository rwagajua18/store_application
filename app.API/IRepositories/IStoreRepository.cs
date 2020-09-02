using System.Collections.Generic;
using app.API.models;
using store_application.API.models;

namespace app.API.IRepositories
{
    public interface IStoreRepository
    {
         //get stores
         //get products from a store
         //get product from the store by its name

         IEnumerable<Store> getStores();

         IEnumerable<Store> getProductsFromStore(int id);

         IEnumerable<Store> getProductFromStore(string storeName, string productName);
    }
}