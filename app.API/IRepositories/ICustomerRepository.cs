using System.Collections.Generic;
using app.API.DTOs;
using app.API.models;

namespace app.API.IRepositories
{
    public interface ICustomerRepository
    {
         //register a customer
         //login a customer
         //delete a customer
         //Customer exists
         //save changes
         //get orders of a particular customer

         IEnumerable<Customer> GetOrders(string lastName, string firstName);
         

         void Register(Customer customer, string password);

         Customer Login(string username, string password);

         void deleteCustomer(Customer customer, string username);

         bool CustomerExists(string username);

         void CommitChanges();

         IEnumerable<Customer> GetCustomers();
    }
}