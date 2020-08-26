
using System.Collections.Generic;
using store_application.API.models;

namespace app.API.IRepositories
{
    public interface IProductRepo
    {

        IEnumerable<Product> Get();

        Product getByProductId(int id);

        void AddProduct(Product product);

        void DeleteProduct(int id);

        void CommitChanges();

        





         
    }
}