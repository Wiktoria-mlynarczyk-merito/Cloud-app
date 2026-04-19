using Microsoft.EntityFrameworkCore;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// 🔐 KEY VAULT
builder.Configuration.AddAzureKeyVault(
    new Uri("https://kv-wiktoria.vault.azure.net/"),
    new DefaultAzureCredential()
);

// kontrolery
builder.Services.AddControllers();

// 🌐 CORS
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

// 🔥 CONNECTION STRING Z KEY VAULT
var connectionString = builder.Configuration["DbConnectionString"];

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();

// routing
app.UseRouting();

// CORS
app.UseCors("AllowFrontend");

// 🔥 FRONTEND (MUSI BYĆ PRZED MAPCONTROLLERS)
app.UseDefaultFiles();   // szuka index.html
app.UseStaticFiles();   // serwuje wwwroot

// API
app.MapControllers();

// migracje
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}



app.Run();