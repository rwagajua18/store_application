using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.API.models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        public string StoreName { get; set; }

        public Location Location { get; set; }

        public int LocationId { get; set; }

        public Inventory Inventory { get; set; }

        public ICollection<Order> Orders { get; set; }


    }

    
}