using dotnet_web_api.Src.Data;
using dotnet_web_api.Src.Interfaces;
using dotnet_web_api.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Src.Repositories
{
    public class ProductRepository(DataContext dataContext) : IProductRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _dataContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(float min, float max)
        {
            return await _dataContext
                .Products.Where(p => p.Price >= min && p.Price <= max)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string term)
        {
            if (string.IsNullOrEmpty(term))
                return await GetAllProductsAsync();

            term = term.ToLower();
#pragma warning disable CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
            return await _dataContext
                .Products.Where(p =>
                    p.Name.ToLower().Contains(term)
                    || (p.Description != null && p.Description.ToLower().Contains(term))
                )
                .ToListAsync();
#pragma warning restore CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
        }

        public async Task<IEnumerable<Product>> GetProductsByStoreAsync(int storeId)
        {
            return await _dataContext.Products.Where(p => p.StoreId == storeId).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetProductsGroupedByStoreAsync()
        {
            return await _dataContext
                .Products.GroupBy(p => p.StoreId)
                .Select(g => new
                {
                    StoreId = g.Key,
                    Count = g.Count(),
                    Products = g.ToList(),
                })
                .ToListAsync();
        }

        public async Task<Product?> GetMostExpensiveProductAsync()
        {
            return await _dataContext
                .Products.OrderByDescending(p => p.Price)
                .FirstOrDefaultAsync();
        }
    }
}
