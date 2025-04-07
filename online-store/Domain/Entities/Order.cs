namespace online_store.Domain.Entities;

public class Order
{
    public required Guid Id  { get; set; }
    public required DateTimeOffset OrderDate { get; set; }
    public required List<Product> Products { get; set; } = [];
    public required decimal Cost { get; set; }
}