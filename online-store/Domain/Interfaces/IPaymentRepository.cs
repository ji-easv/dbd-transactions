using online_store.Domain.Entities;

namespace online_store.Domain.Interfaces;

public interface IPaymentRepository
{
    Task AddAsync(Payment payment);
}