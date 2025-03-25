using dotnet_web_api.Src.Models;

namespace dotnet_web_api.Src.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(float min, float max);
        Task<IEnumerable<Product>> SearchProductsAsync(string term);
        Task<IEnumerable<Product>> GetProductsByStoreAsync(int storeId);
        Task<IEnumerable<object>> GetProductsGroupedByStoreAsync();
        Task<Product?> GetMostExpensiveProductAsync();
    }
}
