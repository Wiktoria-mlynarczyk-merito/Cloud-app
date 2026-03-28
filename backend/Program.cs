using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// kontrolery
builder.Services.AddControllers();

// 🔥 CORS (żeby frontend działał)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// baza danych (Docker - postgres)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=db;Port=5432;Database=tasksdb;Username=postgres;Password=postgres")
);

var app = builder.Build();

app.UseRouting();

// 🔥 CORS
app.UseCors("AllowFrontend");

app.MapControllers();

// 🔥 migracje + czekanie na bazę
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var retries = 10;
    while (retries > 0)
    {
        try
        {
            Console.WriteLine("Łączenie z bazą...");
            db.Database.Migrate();
            Console.WriteLine("Baza gotowa!");
            break;
        }
        catch
        {
            retries--;
            Thread.Sleep(3000);
        }
    }
}

// test
app.MapGet("/", () => "API działa!");

app.Run();