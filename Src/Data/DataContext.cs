using dotnet_web_api.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Src.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
