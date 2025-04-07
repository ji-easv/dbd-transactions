using Microsoft.EntityFrameworkCore;
using online_store.Application.Services;
using online_store.Domain.Entities;
using online_store.Domain.Interfaces;
using online_store.Infrastructure.Contexts;
using online_store.Infrastructure.Repositories;
using online_store.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=OnlineStoreAssignment;User Id=SA;Password=YourStrong@Passw0rd;TrustServerCertificate=True;"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<InventoryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    using var scope = app.Services.CreateScope();
    using var dbContext = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
    dbContext.Database.Migrate();
    
    if (!dbContext.Products.Any())
    {
        var products = new List<Product>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Price = 10.00m,
                Quantity = 100
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Price = 20.00m,
                Quantity = 50
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 3",
                Price = 30.00m,
                Quantity = 25
            }
        };
    
        dbContext.Products.AddRange(products);
        dbContext.SaveChanges();
    }
}
app.MapControllers();

app.Run();