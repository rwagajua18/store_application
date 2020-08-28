using System.Collections.Generic;

namespace app.API.models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string email { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}