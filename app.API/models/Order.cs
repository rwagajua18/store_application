using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.API.models
{
    /// <summary>
    /// Order model
    /// </summary>
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int customerId { get; set; }
        public Customer Customer { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public DateTime OrderCreated { get; set; }
        public ICollection<Order_detail> Order_details {get; set;}
    }
}