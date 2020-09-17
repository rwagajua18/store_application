using System.Collections.Generic;
using app.API.DTOs;
using app.API.models;

namespace app.API.IRepositories
{
    public interface IOrderRepository
    {
        //place an order
        //delete an order
        //display order details of all orders
        //display all orders of a customer
        

        void PlaceOrder(Order order);
        void DeleteOrder(int id);

        IEnumerable<Order> DisplayAllCustomerOrders(int id);
        
    }
}