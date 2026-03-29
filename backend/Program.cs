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

// 🔥 BAZA AZURE SQL (POPRAWIONE)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=tcp:cloud-app-server-wiktoria.database.windows.net,1433;Initial Catalog=tasksdb;User ID=postgres@cloud-app-server-wiktoria;Password=AdminAdmin123$;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
);

var app = builder.Build();

app.UseRouting();

// 🔥 CORS
app.UseCors("AllowFrontend");

app.MapControllers();

// 🔥 MIGRACJE
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// test
app.MapGet("/", () => "API działa!");

app.Run();