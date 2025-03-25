using dotnet_web_api.Src.Data;
using dotnet_web_api.Src.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController(DataContext dataContext) : ControllerBase
    {
        private readonly DataContext _dataContext = dataContext;

        // GET: api/store
        // Obtiene todas las tiendas con información básica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreDto>>> GetStores()
        {
            var stores = await _dataContext
                .Stores.Select(s => new StoreDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Email = s.Email,
                    ProductCount = s.Products.Count,
                })
                .ToListAsync();

            return stores;
        }

        // GET: api/store/5
        // Obtiene una tienda por su ID, incluyendo sus productos
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreWithProductsDto>> GetStore(int id)
        {
            // Primero obtenemos la tienda
            var store = await _dataContext
                .Stores.Where(s => s.Id == id)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Address,
                    s.Email,
                })
                .FirstOrDefaultAsync();

            if (store == null)
            {
                return NotFound();
            }

            var products = await _dataContext
                .Products.Where(p => p.StoreId == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StoreId = p.StoreId,
                    StoreName = store.Name,
                })
                .ToListAsync();

            var storeWithProducts = new StoreWithProductsDto
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address,
                Email = store.Email,
                Products = products,
            };

            return storeWithProducts;
        }

        // GET: api/store/5/products
        // Obtiene todos los productos de una tienda específica
        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetStoreProducts(int id)
        {
            var store = await _dataContext.Stores.FindAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            var products = await _dataContext
                .Products.Where(p => p.StoreId == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StoreId = p.StoreId,
                    StoreName = store.Name,
                })
                .ToListAsync();

            return products;
        }

        // GET: api/store/search?name=Norte
        // Busca tiendas por nombre
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<StoreDto>>> SearchStores([FromQuery] string name)
        {
            var stores = await _dataContext
                .Stores.Where(s => s.Name.Contains(name))
                .Select(s => new StoreDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Email = s.Email,
                    ProductCount = s.Products.Count,
                })
                .ToListAsync();

            return stores;
        }
    }
}
