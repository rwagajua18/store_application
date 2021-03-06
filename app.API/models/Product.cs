using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using app.API.models;

namespace store_application.API.models
{
    /// <summary>
    /// Product model
    /// </summary>
    public class Product
    {
        [Key]
        public int ProdId { get; set; }
        public string Name { get; set; }
    
        public decimal Price { get; set; }

        public Category category { get; set; }

        public int categoryID { get; set; }

        public ICollection<Order_detail> Order_Details{get; set;}

    

        

    }
}