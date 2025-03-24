using dotnet_web_api.Src.Data;
using dotnet_web_api.Src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        // GET: api/store
        // Obtiene todas las tiendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }

        // GET: api/store/5
        // Obtiene una tienda por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            throw new NotImplementedException();
        }

        // GET: api/store/5/products
        // Obtiene todos los productos de una tienda específica
        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetStoreProducts(int id)
        {
            throw new NotImplementedException();
        }

        // GET: api/store/search?name=Norte
        // Busca tiendas por nombre
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Store>>> SearchStores([FromQuery] string name)
        {
            throw new NotImplementedException();
        }

        // GET: api/store/products/price?min=100&max=500
        // Obtiene productos en un rango de precios
        [HttpGet("products/price")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByPriceRange(
            [FromQuery] float min,
            [FromQuery] float max
        )
        {
            throw new NotImplementedException();
        }

        // GET: api/store/products/count
        // Obtiene el número de productos por tienda
        [HttpGet("products/count")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductCountByStore()
        {
            throw new NotImplementedException();
        }

        // GET: api/store/products/expensive
        // Obtiene el producto más caro de cada tienda
        [HttpGet("products/expensive")]
        public async Task<ActionResult<IEnumerable<object>>> GetMostExpensiveProductsByStore()
        {
            throw new NotImplementedException();
        }
    }
}
