using Microsoft.EntityFrameworkCore;
using online_store.Domain.Entities;

namespace online_store.Infrastructure.Contexts;

public class ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(order =>
        {
            order
                .HasMany(o => o.Products)
                .WithMany();

            order.Property(o => o.Cost)
                .HasPrecision(18, 2);
        });

        modelBuilder.Entity<Payment>(payment =>
        {
            payment
                .HasOne(p => p.Order)
                .WithOne()
                .HasForeignKey<Payment>(p => p.OrderId);
            
            payment.Property(p => p.Amount)
                .HasPrecision(18, 2);
        }); 
        
        modelBuilder.Entity<Product>(product =>
        {
            product
                .Property(p => p.Price)
                .HasPrecision(18, 2);
        });


        base.OnModelCreating(modelBuilder);
    }
}