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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
            .HasKey(c => new{c.StoreId, c.ProdId});

            
        }
        
    }
}