using System;
using app.API.IRepositories;
using app.API.models;
using store_application.API.models.Data;
using System.Linq;
using System.Collections.Generic;
using app.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace app.API.Repositories
{
    /// <summary>
    /// customer repository
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {

        /// <summary>
        /// Database context field
        /// </summary>
        private readonly StoreContext _context;
        public CustomerRepository(StoreContext context)
        {
            _context = context;
            
        }

        /// <summary>
        /// gets all customers from the database
        /// </summary>
        /// <returns>a list of customers</returns>
         public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        
        /// <summary>
        /// Checks if a customer exists
        /// </summary>
        /// <param name="username"></param>
        /// <returns>boolean</returns>
        public bool CustomerExists(string username)
        {
            var customer = _context.Customers.FirstOrDefault(u => u.Username == username);
            if(customer == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// deletes a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="username"></param>
        public void deleteCustomer(Customer customer, string username)
        {
            if(CustomerExists(username))
            {
                _context.Remove(customer);
            }
        }


        /// <summary>
        /// logs in a customer 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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


        /// <summary>
        /// registers a customer in the database.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="password"></param>
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


        /// <summary>
        /// saves changes to the database
        /// </summary>
        public void CommitChanges()
        {
            _context.SaveChanges();
        }


        /// <summary>
        /// converts a plain password text to a password hash and salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
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

        /// <summary>
        /// gets orders of a particular customer
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public IEnumerable<Customer> GetOrders(string lastName, string firstName)
        {
            var orders = _context.Customers
                         .Include(o => o.Orders).Where(c => c.LastName == lastName && c.FirstName == firstName).ToList();

        
            return orders;
            

        }
    }
}