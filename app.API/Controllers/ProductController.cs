using Microsoft.AspNetCore.Mvc;
using store_application.API.models.Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using store_application.API.models;
using System.Linq;

namespace app.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, StoreContext context)
        {
            _context = context;
            _logger = logger;
            
        }

        [HttpGet]
        public IActionResult  Get()
        {
            var products = _context.Products;
            if(products == null)
            {
                return NotFound(products);
            }
            return Ok(products);
        }

        [HttpGet("{id}")]

        public IActionResult GetProductId(int id)
        {
            if(id <= 0)
            {
                return NotFound("id does not exist");
            }
            var product = _context.Products.FirstOrDefault(x => x.ProdId == id);
            return Ok(product);

        }


    }
}