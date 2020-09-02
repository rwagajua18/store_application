using Microsoft.AspNetCore.Mvc;
using store_application.API.models.Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using store_application.API.models;
using System.Linq;
using app.API.IRepositories;
using Microsoft.AspNetCore.Authorization;

namespace app.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        //private readonly StoreContext _context;
        private readonly ILogger<ProductController> _logger;

        private readonly IProductRepo _productRepo;

        public ProductController(ILogger<ProductController> logger, IProductRepo productRepo)
        {
            _productRepo = productRepo;
            _logger = logger;
            
        }

        [HttpGet]
        public IActionResult  Get()
        {
            var products = _productRepo.Get();
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
            var product = _productRepo.getByProductId(id);
            return Ok(product);

        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productRepo.AddProduct(product);
            _productRepo.CommitChanges();

            return Accepted(product);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }
            _productRepo.DeleteProduct(id);
            _productRepo.CommitChanges();
            return Ok();
        }


    }
}