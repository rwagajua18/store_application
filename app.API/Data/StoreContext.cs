using Microsoft.EntityFrameworkCore;

namespace store_application.API.models.Data
{
    public class StoreContext : DbContext
    {

        public StoreContext(DbContextOptions<StoreContext> options): base(options){}
        

        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories {get; set;}
        
    }
}