using app.API.DTOs;
using app.API.IRepositories;
using app.API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app.API.Controllers
{
      
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController: ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _logger = logger;

        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            return Ok(customers);
        }

        [HttpPost("{Register}")]
        public IActionResult Register(CustomerDTO customer)
        {
            var newCustomer = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Username = customer.Username,
                email = customer.email,
                LocationId = customer.LocationId
   
            };

            _customerRepository.Register(newCustomer, customer.password);
            _customerRepository.CommitChanges();
            return Accepted(newCustomer);



        }
    }
}