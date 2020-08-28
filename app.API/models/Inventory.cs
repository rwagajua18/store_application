using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using store_application.API.models;

namespace app.API.models
{
    public class Inventory
    {
        [Key]
        [Column(Order = 1)]
        public int StoreId { get; set; }
        public Store Store { get; set; }


        [Key]
        [Column(Order = 2)]
        public int ProdId { get; set; }

        public Product Product { get; set; }

        public int Stock { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}