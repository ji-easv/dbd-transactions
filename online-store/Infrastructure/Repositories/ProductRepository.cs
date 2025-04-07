using online_store.Domain.Entities;
using online_store.Domain.Interfaces;
using online_store.Infrastructure.Contexts;

namespace online_store.Infrastructure.Repositories;

public class ProductRepository(ECommerceDbContext dbContext) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var product = await dbContext.Products.FindAsync(id);
        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();
    }
}