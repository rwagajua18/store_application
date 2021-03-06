using System.Collections.Generic;

namespace app.API.models
{
    /// <summary>
    /// customer model
    /// </summary>
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public byte[] passwordHash { get; set; }

        public byte[] passwordSalt {get;set;}

        public string email { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}