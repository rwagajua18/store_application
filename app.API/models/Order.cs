using System;
using System.ComponentModel.DataAnnotations;

namespace app.API.models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int customerId { get; set; }
        public Customer Customer { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public DateTime OrderCreated { get; set; }
    }
}