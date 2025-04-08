using System.Data;
using online_store.Application.DTOs;
using online_store.Domain.Entities;
using online_store.Domain.Interfaces;

namespace online_store.Application.Services;

public class OrderService(
    IProductRepository productRepository,
    IOrderRepository orderRepository,
    IPaymentRepository paymentRepository,
    IUnitOfWork unitOfWork
)
{
    public async Task<bool> PlaceOrderAsync(PlaceOrderDTO orderDto)
    {
        await using var transaction = await unitOfWork.BeginTransactionAsync(IsolationLevel.Serializable);
        try
        {
            // Check if all products are available
            var products = new List<Product>();
            decimal orderTotalCost = 0;

            foreach (var lineItem in orderDto.OrderLineItems)
            {
                var product = await productRepository.GetByIdAsync(lineItem.ProductId);
                if (product == null || product.Quantity < lineItem.Quantity)
                {
                    return false;
                }

                product.Quantity -= lineItem.Quantity;
                orderTotalCost += product.Price * lineItem.Quantity;
                products.Add(product);
            }

            // Create order
            var order = new Order
            {
                Id = Guid.CreateVersion7(),
                OrderDate = DateTimeOffset.Now,
                Products = products,
                Cost = orderTotalCost
            };

            await orderRepository.AddAsync(order);

            // Update stock
            foreach (var product in products)
            {
                await productRepository.UpdateAsync(product);
            }

            // Create payment
            var payment = new Payment
            {
                Id = Guid.CreateVersion7(),
                OrderId = order.Id,
                Status = PaymentStatus.Pending,
                PaymentDate = null,
                Amount = orderTotalCost
            };

            await paymentRepository.AddAsync(payment);

            // Save changes
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
}