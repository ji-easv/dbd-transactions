namespace online_store.Domain.Entities;

public class Payment
{
    public required Guid Id { get; set; }
    public required decimal Amount { get; set; }
    public required DateTimeOffset? PaymentDate { get; set; }
    public required PaymentStatus Status { get; set; }
    
    public required Guid OrderId { get; set; }
    public Order? Order { get; set; }
}

public enum PaymentStatus
{
    Pending,
    Processing,
    Completed
}