using System.Collections.Generic;
using System.Linq;
using app.API.DTOs;
using app.API.IRepositories;
using app.API.models;
using Microsoft.EntityFrameworkCore;
using store_application.API.models.Data;

namespace app.API.Repositories
{
    /// <summary>
    /// order repository
    /// </summary>
    public class OrderRepository: IOrderRepository
    {
        /// <summary>
        /// database context field
        /// </summary>
        private readonly StoreContext _context;
        public OrderRepository(StoreContext context)
        {
            _context = context;

        }


        /// <summary>
        /// deletes an order
        /// </summary>
        /// <param name="id"></param>
        public void DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            _context.Orders.Remove(order);
        }


        /// <summary>
        /// displays order details of a customer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Order> DisplayAllCustomerOrders(int id)
        {
            return (_context.Orders
                   .Include(o => o.Order_details).Where(o => o.customerId == id)).ToList();
            
        }


        /// <summary>
        /// places an order
        /// </summary>
        /// <param name="order"></param>
        public void PlaceOrder(Order order)
        {

            _context.Orders.Add(order);
            
        }

        
    }
}