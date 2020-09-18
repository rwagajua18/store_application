using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using store_application.API.models;

namespace app.API.models
{
    /// <summary>
    /// Inventory model
    /// </summary>
    public class Inventory
    {
        [Key]
        public int StoreId { get; set; }
        public Store Store { get; set; }
        
        [Key]
        public int ProdId { get; set; }

        public Product Product { get; set; }


        public int Stock { get; set; }



    
    }
}