using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace store_application.API.models
{

    /// <summary>
    /// category model
    /// </summary>
    public class Category
    {
        
        [Key]
        public int CategoryId { get; set; }
        public string catName { get; set; }

        public ICollection<Product> Products {get; set;}
    }
}