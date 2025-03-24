var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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

app.Run();
