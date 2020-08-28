using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.API.models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public ICollection<Store> Stores { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}