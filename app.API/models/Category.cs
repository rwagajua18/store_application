using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace store_application.API.models
{
    public class Category
    {
        [Key]
        public int catID { get; set; }
        public string catName { get; set; }

        public ICollection<Product> Products {get; set;}
    }
}