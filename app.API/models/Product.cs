using System.ComponentModel.DataAnnotations;
namespace store_application.API.models
{
    public class Product
    {
        [Key]
        public int ProdId { get; set; }
        public string Name { get; set; }
    
        public decimal Price { get; set; }

        public Category category { get; set; }

        public int categoryID { get; set; }

        

    }
}