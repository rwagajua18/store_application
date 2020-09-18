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

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
        public class ProductController : ControllerBase
    {

        /// <summary>
        /// product repository field
        /// </summary>

        private readonly IProductRepo _productRepo;

        /// <summary>
        /// Product constructor. Initializes fields
        /// </summary>
        /// <param name="productRepo"></param>

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
            
            
        }

        /// <summary>
        /// gets all products
        /// </summary>
        /// <returns></returns>

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

        /// <summary>
        /// returns a specific product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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

        /// <summary>
        /// adds a product to the system
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productRepo.AddProduct(product);
            _productRepo.CommitChanges();

            return Accepted(product);
        }


        /// <summary>
        /// delets a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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