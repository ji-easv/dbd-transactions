namespace online_store.Application.DTOs;

public class OrderLineItemDTO
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class PlaceOrderDTO
{
    public OrderLineItemDTO[] OrderLineItems { get; set; }
}