using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using store_application.API.models.Data;
using System.Linq;
using System.Threading.Tasks;

namespace app.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController: ControllerBase
    {
        private readonly ILogger<StoreController> _logger;
        private readonly StoreContext _context;

        public StoreController(ILogger<StoreController> logger, StoreContext context)
        {
            _context = context;
            _logger = logger;

        }
        [HttpGet]
        public IActionResult GetStores()
        {
            var stores = _context.Stores;

            if(stores == null)
            {
                return BadRequest("Stores not found");
            }

            return Ok(stores);
            
        }

        [HttpGet("{id}")]

        public  IActionResult GetProductsFromStore(int id)
        {
            if(id <= 0)
            {
                return BadRequest("The id does not exist");
            }

            var products = _context.Stores
                           .Include(i => i.Inventory)
                           .ThenInclude(p => p.Product)
                           .Where(s => s.StoreId == id);

            return Ok(products);
        }


    }
}