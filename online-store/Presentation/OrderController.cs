using Microsoft.AspNetCore.Mvc;
using online_store.Application.DTOs;
using online_store.Application.Services;

namespace online_store.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;
    
    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder([FromBody] PlaceOrderDTO orderDto)
    {
        var result = await _orderService.PlaceOrderAsync(orderDto);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
}