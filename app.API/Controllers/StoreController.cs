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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController: ControllerBase
    {

        
        /// <summary>
        /// store repository field
        /// </summary>
        private readonly IStoreRepository _storeRepository;

        /// <summary>
        /// Initializes fields
        /// </summary>
        /// <param name="storeRepository"></param>
        public StoreController(IStoreRepository storeRepository)
        {
            
            _storeRepository = storeRepository;
        }

        /// <summary>
        /// gets all stores
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// gets all products from a specific store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public  IActionResult GetProductsFromStore(int id)
        {
            if(id <= 0)
            {
                return BadRequest("The id does not exist");
            }
            
            return Ok(_storeRepository.getProductsFromStore(id));
        }

        /// <summary>
        /// get a product by its name from a specific store.
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="productName"></param>
        /// <returns></returns>

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