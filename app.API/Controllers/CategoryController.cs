using Microsoft.AspNetCore.Mvc;
using store_application.API.models.Data;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace app.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController: ControllerBase
    {
        private readonly StoreContext _context;

        private ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, StoreContext context)
        {
            _logger = logger;
            _context = context;
            
        }

        
        /// <summary>
        /// returns a list of all categories
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _context.Categories.ToList();

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
            var products = _context.Categories
                           .Include(p => p.Products)
                           .FirstOrDefault(x => x.catID == id);
            return Ok(products);
            
        }
        

        
    }
}