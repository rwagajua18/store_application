using app.API.models;
using Microsoft.EntityFrameworkCore;

namespace store_application.API.models.Data
{
    public class StoreContext : DbContext
    {

        public StoreContext(DbContextOptions<StoreContext> options): base(options){}
        

        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories {get; set;}

        public DbSet<Inventory> Inventory {get;set;}

        public DbSet<Store> Stores { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order_detail> Order_Details {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //creating a composite key for inventory
            modelBuilder.Entity<Inventory>()
            .HasKey(c => new{c.StoreId, c.ProdId});

            //creating a composite key for order_detail
            modelBuilder.Entity<Order_detail>()
            .HasKey(o => new{o.OrderId, o.ProdId});

            
        }
        
    }
}