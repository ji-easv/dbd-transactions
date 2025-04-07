using online_store.Domain.Entities;

namespace online_store.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task UpdateAsync(Product product);
}