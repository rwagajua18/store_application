using app.API.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using store_application.API.models.Data;
using System.Linq;
using System.Threading.Tasks;

namespace app.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController: ControllerBase
    {
        private readonly ILogger<StoreController> _logger;
        
        private readonly IStoreRepository _storeRepository;

        public StoreController(ILogger<StoreController> logger,IStoreRepository storeRepository)
        {
            
            _logger = logger;
            _storeRepository = storeRepository;
        }
        [HttpGet]
        public IActionResult GetStores()
        {
            var stores = _storeRepository.getStores();
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
            
            return Ok(_storeRepository.getProductsFromStore(id));
        }

        [HttpGet("{storeName}/{productName}")]

        public IActionResult GetProductByName(string storeName, string productName)
        {
            if(storeName == null && productName == null)
            {
                return BadRequest("Invalid inputs");
            }

            var product = _storeRepository.getProductFromStore(storeName, productName);

            return Ok(product);
        }


    }
}