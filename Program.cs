using dotnet_web_api.Src.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("StoreDb"));

var app = builder.Build();

app.MapControllers();

app.Use(
    async (context, next) =>
    {
        var start = DateTime.UtcNow;

        await next.Invoke();

        var elapsed = DateTime.UtcNow - start;
        Console.WriteLine($"Solicitud procesada en {elapsed.TotalMilliseconds}ms");
    }
);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>();
        Seeder.Seed(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al poblar la base de datos.");
    }
}

app.Run();
