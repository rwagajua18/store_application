using Microsoft.AspNetCore.Mvc;
using store_application.API.models.Data;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using app.API.IRepositories;
using Microsoft.AspNetCore.Authorization;

namespace app.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController: ControllerBase
    {
        /// <summary>
        /// category repository field
        /// </summary>
        private readonly ICategoryRepo _categoryRepo;
        
    

        public CategoryController(ICategoryRepo categoryRepo)
        {
        
            _categoryRepo = categoryRepo;
            
        }

        
        /// <summary>
        /// returns a list of all categories
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryRepo.Get();

            return Ok(categories);
        }

        /// <summary>
        /// returns a list of products from a particular category.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet("{id}")]
        
        public IActionResult GetProducts(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Invalid ID");
            }
            var products = _categoryRepo.GetProductsFromCategory(id);         
            return Ok(products);
            
        }
        

        
    }
}