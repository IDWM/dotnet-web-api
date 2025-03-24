using dotnet_web_api.Src.Data;
using dotnet_web_api.Src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        // GET: api/Product
        // Obtiene todos los productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            throw new NotImplementedException();
        }

        // GET: api/Product/5
        // Obtiene un producto por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        // GET: api/Product/price-range?min=100&max=500
        // Filtra productos por rango de precio
        [HttpGet("price-range")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByPriceRange(
            [FromQuery] float min,
            [FromQuery] float max
        )
        {
            throw new NotImplementedException();
        }

        // GET: api/Product/search?term=laptop
        // Busca productos por nombre o descripción
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts(
            [FromQuery] string term
        )
        {
            throw new NotImplementedException();
        }

        // GET: api/Product/store/1
        // Obtiene productos de una tienda específica
        [HttpGet("store/{storeId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByStore(int storeId)
        {
            throw new NotImplementedException();
        }

        // GET: api/Product/group-by-store
        // Agrupa productos por tienda y cuenta cuántos hay en cada una
        [HttpGet("group-by-store")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductsGroupedByStore()
        {
            throw new NotImplementedException();
        }

        // GET: api/Product/expensive
        // Obtiene el producto más caro
        [HttpGet("expensive")]
        public async Task<ActionResult<Product>> GetMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }
    }
}
