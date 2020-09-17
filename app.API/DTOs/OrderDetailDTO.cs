using store_application.API.models;

namespace app.API.DTOs
{
    public class OrderDetailDTO
    {
        //public int OrderId { get; set; }

        //public int ProdId { get; set; }

        public Product Product{get; set;}

        public int Quantity { get; set; }

        public int Unit_price { get; set; }

        public decimal Total {get;set;}
        
        
    }
}