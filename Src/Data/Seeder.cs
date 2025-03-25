using Bogus;
using dotnet_web_api.Src.Models;

namespace dotnet_web_api.Src.Data
{
    public static class Seeder
    {
        public static void Seed(DataContext dataContext)
        {
            // Verificar si ya hay datos
            if (dataContext.Stores.Any())
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

            dataContext.Stores.AddRange(stores);
            dataContext.SaveChanges();

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

            dataContext.Products.AddRange(products);
            dataContext.SaveChanges();
        }

        public static void SeedWithFaker(DataContext dataContext)
        {
            // Verificar si ya hay datos
            if (dataContext.Stores.Any())
            {
                return; // La base de datos ya tiene datos
            }

            // Configurar faker en español
            Faker.DefaultStrictMode = false; // Cambiar a false para permitir propiedades sin reglas
            var faker = new Faker("es");

            // Número aleatorio de tiendas entre 3 y 10
            var storeQuantity = faker.Random.Int(3, 10);

            // Crear generador de tiendas con restricciones de longitud
            var storeFaker = new Faker<Store>("es")
                .RuleFor(s => s.Id, f => f.UniqueIndex + 1)
                .RuleFor(
                    s => s.Name,
                    f =>
                    {
                        var name = f.Company.CompanyName();
                        return name.Length > 20 ? name[..20] : name;
                    }
                )
                .RuleFor(
                    s => s.Address,
                    f =>
                    {
                        var address = $"{f.Address.StreetAddress()}, {f.Address.City()}";
                        return address.Length > 100 ? address[..100] : address;
                    }
                )
                .RuleFor(
                    s => s.Email,
                    (f, s) =>
                    {
                        // Normalizar el nombre para email (quitar espacios y acentos)
                        var name = s
                            .Name.ToLower()
                            .Replace(" ", "")
                            .Replace("á", "a")
                            .Replace("é", "e")
                            .Replace("í", "i")
                            .Replace("ó", "o")
                            .Replace("ú", "u")
                            .Replace(".", "")
                            .Replace(",", "");

                        name = name.Length > 10 ? name[..10] : name;
                        return f.Internet.Email(name);
                    }
                )
                .RuleFor(s => s.Products, f => []); // Inicializar la lista de productos

            // Generar tiendas
            var stores = storeFaker.Generate(storeQuantity);
            dataContext.Stores.AddRange(stores);
            dataContext.SaveChanges();

            // Número aleatorio de productos entre 6 y 20 por tienda
            var productsPerStore = faker.Random.Int(6, 20);

            // Generar productos para cada tienda
            foreach (var store in stores)
            {
                var productFaker = new Faker<Product>("es")
                    .RuleFor(p => p.Id, f => 0) // La base de datos generará el ID
                    .RuleFor(
                        p => p.Name,
                        f =>
                        {
                            var name = f.Commerce.ProductName();
                            return name.Length > 20 ? name[..20] : name;
                        }
                    )
                    .RuleFor(
                        p => p.Description,
                        f =>
                        {
                            var description = f.Commerce.ProductDescription();
                            return description.Length > 100 ? description[..100] : description;
                        }
                    )
                    // Usar float explícitamente en lugar de double
                    .RuleFor(
                        p => p.Price,
                        f => (float)Math.Round(f.Random.Float(50.0f, 15000.0f), 2)
                    )
                    .RuleFor(p => p.StoreId, f => store.Id)
                    .RuleFor(p => p.Store, f => store);

                var products = productFaker.Generate(productsPerStore);
                dataContext.Products.AddRange(products);
            }

            dataContext.SaveChanges();
        }
    }
}
