using System.ComponentModel.DataAnnotations;
using store_application.API.models;

namespace app.API.models
{
    public class Order_detail
    {
        [Key]
        public int OrderId { get; set; }

        public Order order {get; set;}
        
        [Key]
        public int ProdId { get; set; }

        public Product Product{get; set;}

        public int Quantity { get; set; }

        public int Unit_price { get; set; }

        public decimal Total {get;set;}
        
    }
}