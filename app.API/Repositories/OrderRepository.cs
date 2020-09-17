using System.Collections.Generic;
using System.Linq;
using app.API.DTOs;
using app.API.IRepositories;
using app.API.models;
using Microsoft.EntityFrameworkCore;
using store_application.API.models.Data;

namespace app.API.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly StoreContext _context;
        public OrderRepository(StoreContext context)
        {
            _context = context;

        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            _context.Orders.Remove(order);
        }

        public IEnumerable<Order> DisplayAllCustomerOrders(int id)
        {
            return (_context.Orders
                   .Include(o => o.Order_details).Where(o => o.customerId == id)).ToList();

            
        }

        public void PlaceOrder(Order order)
        {

            _context.Orders.Add(order);
            
        }

        
    }
}