using Microsoft.AspNetCore.Mvc;
using online_store.Application.DTOs;
using online_store.Application.Services;

namespace online_store.Presentation;

[ApiController]
[Route("[controller]")]
public class OrderController(OrderService orderService, InventoryService inventoryService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder([FromBody] PlaceOrderDTO orderDto)
    {
        var result = await orderService.PlaceOrderAsync(orderDto);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
    
    [HttpGet("stock/{productId}")]
    public async Task<IActionResult> GetStock(Guid productId)
    {
        var stock = await inventoryService.GetStock(productId);
        if (stock >= 0)
        {
            return Ok(stock);
        }
        return NotFound();
    }
}