using System.ComponentModel.DataAnnotations;

namespace online_store.Domain.Entities;

public class Product
{
    public required Guid Id { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int Quantity { get; set; }
}