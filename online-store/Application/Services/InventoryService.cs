using System.Data;
using online_store.Domain.Interfaces;

namespace online_store.Application.Services;

public class InventoryService(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
) 
{
    public async Task<int> GetStock(Guid productId)
    {
        await using var transaction = await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadUncommitted);
        
        var product = await productRepository.GetByIdAsync(productId);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        
        return product.Quantity;
    }
}