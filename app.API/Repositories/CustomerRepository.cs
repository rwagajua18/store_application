using System;
using app.API.IRepositories;
using app.API.models;
using store_application.API.models.Data;
using System.Linq;
using System.Collections.Generic;
using app.API.DTOs;

namespace app.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        
        private readonly StoreContext _context;
        public CustomerRepository(StoreContext context)
        {
            _context = context;
            
        }

         public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        

        public bool CustomerExists(string username)
        {
            var customer = _context.Customers.FirstOrDefault(u => u.Username == username);
            if(customer == null)
            {
                return false;
            }
            return true;
        }

        public void deleteCustomer(Customer customer, string username)
        {
            if(CustomerExists(username))
            {
                _context.Remove(customer);
            }
        }

        public Customer Login(string username, string password)
        {
            var customer = _context.Customers.FirstOrDefault(u => u.Username == username);

            //compute the password hash of the given string password
            using(var hmac = new System.Security.Cryptography.HMACSHA512(customer.passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                //comparing the computedhash and the one saved from the database
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != customer.passwordHash[i])
                    {
                        return null;
                    }

                }

            }return customer;
            



            
        }

        public void Register(Customer customer, string password)
        {
            //create properties that will hold the password hash and salt. the properties have a byte array to hold 
            //the passwords
            byte[] passwordHash, passwordSalt;

            //method for converting the password string to a hash and salt
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //assigning the newly created password hash and salt to the properties in the customer
            customer.passwordHash = passwordHash;
            customer.passwordSalt = passwordSalt;

            //add the user in the sytem
            _context.Add(customer);

        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //disposes the instance after being used.
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;

                //computes tha password hash from the password string. The password string is first converted to bytes using
                //sytem.text.Encoding.UTF8.Getbytes()
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));



            }

        }

       
    }
}