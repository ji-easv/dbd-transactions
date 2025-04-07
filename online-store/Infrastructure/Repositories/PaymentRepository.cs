using online_store.Domain.Entities;
using online_store.Domain.Interfaces;
using online_store.Infrastructure.Contexts;

namespace online_store.Infrastructure.Repositories;

public class PaymentRepository(ECommerceDbContext dbContext) : IPaymentRepository
{
    public async Task AddAsync(Payment payment)
    {
        await dbContext.Payments.AddAsync(payment);
        await dbContext.SaveChangesAsync();
    }
}