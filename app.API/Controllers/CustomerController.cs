using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using app.API.DTOs;
using app.API.IRepositories;
using app.API.models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


namespace app.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// customer repository field
        /// </summary>
        private readonly ICustomerRepository _customerRepository;
        /// <summary>
        /// mapper field
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// order repository
        /// </summary>
        private readonly IOrderRepository _orderRepository;

        private readonly IConfiguration _config;

        /// <summary>
        /// constructor.Initializes fields
        /// </summary>
        /// <param name="customerRepository"></param>
        /// <param name="orderRepository"></param>
        /// <param name="config"></param>
        /// <param name="mapper"></param>
        public CustomerController( ICustomerRepository customerRepository,
                                  IOrderRepository orderRepository, IConfiguration config, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _config = config;
            _customerRepository = customerRepository;
            

        }

        /// <summary>
        /// gets all customers
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();

            var customerToReturn = _mapper.Map<IEnumerable<CustomerDetailDTO>>(customers);
            return Ok(customerToReturn);
        }

        /// <summary>
        /// registers a customer in the system
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>

        [HttpPost("register")]
        public IActionResult Register(CustomerRegister customer)
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

        /// <summary>
        /// Allows a customer to login
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>

        [HttpPost("login")]

        public IActionResult Login(CustomerLoginDTO customer)
        {
            //checking if the user is logged in
            var customerRepository = _customerRepository.Login(customer.username.ToLower(), customer.password);
            if (customerRepository == null)
            {
                return Unauthorized();
            }

            //create claims that will be passed to a token

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, customerRepository.CustomerId.ToString()),
                new Claim(ClaimTypes.Name, customerRepository.Username)
            };

            //create a key to sign the token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1), //Token expires in a day
                SigningCredentials = credentials
            };

            var TokenHandler = new JwtSecurityTokenHandler();

            var Token = TokenHandler.CreateToken(tokenDescriptor);

            //return the jwt token to the client
            return Ok(new
            {
                token = TokenHandler.WriteToken(Token)
            });



        }

        /// <summary>
        /// return orders of a specified customer
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>

        [HttpGet("{lastName}/{firstName}")]
        public IActionResult getOrders(string lastName, string firstName)
        {
            if (lastName == null && firstName == null)
            {
                return BadRequest("No names specified");
            }

            var customerOrders = _customerRepository.GetOrders(lastName, firstName);

            var customerOrderToReturn = _mapper.Map<IEnumerable<CustomerOrders>>(customerOrders);

            return Ok(customerOrderToReturn);
        }

        /// <summary>
        /// adds an order to the system.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult PostOrder(Order order)
        {
            var orderToPost = _mapper.Map<IEnumerable<OrderDTO>>(order);
           
            _orderRepository.PlaceOrder((Order)orderToPost);
            return Ok();
        }


    }
}