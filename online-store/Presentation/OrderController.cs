using Microsoft.AspNetCore.Mvc;
using online_store.Application.DTOs;
using online_store.Application.Services;

namespace online_store.Presentation;

[ApiController]
[Route("[controller]")]
public class OrderController(OrderService orderService) : ControllerBase
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
}