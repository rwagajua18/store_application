using System.Collections.Generic;
using app.API.models;

namespace app.API.DTOs
{
    public class CustomerOrders
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }


        public ICollection<Order> Orders { get; set; }

    }
}