using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using app.API.DTOs;
using app.API.IRepositories;
using app.API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


namespace app.API.Controllers
{
      
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController: ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository _customerRepository;

         private readonly IConfiguration _config;
        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository customerRepository,
                                  IConfiguration config)
        {
            _config = config;
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

        [HttpPost]

        public IActionResult Login(CustomerLoginDTO customer)
        {
            //checking if the user is logged in
            var customerRepository = _customerRepository.Login(customer.username.ToLower(), customer.password);
            if(customerRepository == null)
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
            return Ok(new{
                token = TokenHandler.WriteToken(Token)
            });



        }

        [HttpGet("{lastName}/{firstName}")]
        public IActionResult getOrders(string lastName, string firstName)
        {
            if(lastName == null && firstName == null)
            {
                return BadRequest("No names specified");
            }

            var orders = _customerRepository.GetOrders(lastName, firstName);
            return Ok(orders);
        }
    }
}