using dotnet_web_api.Src.Data;
using dotnet_web_api.Src.DTOs;
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
        // Obtiene todas las tiendas con información básica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreDto>>> GetStores()
        {
            var stores = await _context
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
            var store = await _context
                .Stores.Include(s => s.Products)
                .Where(s => s.Id == id)
                .Select(s => new StoreWithProductsDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Email = s.Email,
                    Products = s
                        .Products.Select(p => new ProductDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Description = p.Description,
                            Price = p.Price,
                            StoreId = p.StoreId,
                            StoreName = s.Name,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync();

            if (store == null)
            {
                return NotFound();
            }

            return store;
        }

        // GET: api/store/5/products
        // Obtiene todos los productos de una tienda específica
        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetStoreProducts(int id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            var products = await _context
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
            var stores = await _context
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
