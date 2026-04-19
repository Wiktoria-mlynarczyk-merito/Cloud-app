using Microsoft.EntityFrameworkCore;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddAzureKeyVault(
    new Uri("https://kv-wiktoria.vault.azure.net/"),
    new DefaultAzureCredential()
);


builder.Services.AddControllers();


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


var connectionString = builder.Configuration["DbConnectionString"];

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();

// routing
app.UseRouting();

// CORS
app.UseCors("AllowFrontend");

// frontend
app.UseDefaultFiles();
app.UseStaticFiles();

// API
app.MapControllers();

// migracje
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// test
app.MapGet("/", () => "API działa!");

app.Run();