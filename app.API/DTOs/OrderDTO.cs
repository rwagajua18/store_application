using System;
using System.Collections.Generic;
using app.API.models;
using store_application.API.models;

namespace app.API.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int customerId { get; set; }
        public DateTime OrderCreated { get; set; }


       
        
    }
}