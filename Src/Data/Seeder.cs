using dotnet_web_api.Src.Models;

namespace dotnet_web_api.Src.Data
{
    public static class Seeder
    {
        public static void Seed(DataContext context)
        {
            // Verificar si ya hay datos
            if (context.Stores.Any())
            {
                return; // La base de datos ya tiene datos
            }

            // Crear tiendas
            var stores = new List<Store>
            {
                new()
                {
                    Id = 1,
                    Name = "Tienda Central",
                    Address = "Calle Principal 123",
                    Email = "central@tienda.com",
                },
                new()
                {
                    Id = 2,
                    Name = "Tienda Norte",
                    Address = "Avenida Norte 456",
                    Email = "norte@tienda.com",
                },
                new()
                {
                    Id = 3,
                    Name = "Tienda Sur",
                    Address = "Plaza Sur 789",
                    Email = "sur@tienda.com",
                },
            };

            context.Stores.AddRange(stores);
            context.SaveChanges();

            // Crear productos
            var products = new List<Product>
            {
                new()
                {
                    Id = 1,
                    Name = "Laptop",
                    Description = "Laptop de alta gama",
                    Price = 1200.00f,
                    StoreId = 1,
                    Store = stores[0],
                },
                new()
                {
                    Id = 2,
                    Name = "Smartphone",
                    Description = "Smartphone último modelo",
                    Price = 800.00f,
                    StoreId = 1,
                    Store = stores[0],
                },
                new()
                {
                    Id = 3,
                    Name = "Tablet",
                    Description = "Tablet profesional",
                    Price = 600.00f,
                    StoreId = 2,
                    Store = stores[1],
                },
                new()
                {
                    Id = 4,
                    Name = "Monitor",
                    Description = "Monitor 4K",
                    Price = 400.00f,
                    StoreId = 2,
                    Store = stores[1],
                },
                new()
                {
                    Id = 5,
                    Name = "Teclado",
                    Description = "Teclado mecánico",
                    Price = 120.00f,
                    StoreId = 3,
                    Store = stores[2],
                },
                new()
                {
                    Id = 6,
                    Name = "Mouse",
                    Description = "Mouse ergonómico",
                    Price = 50.00f,
                    StoreId = 3,
                    Store = stores[2],
                },
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
