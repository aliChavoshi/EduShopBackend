using Application.Dtos.OrderDto;
using Application.Features.Orders.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers;

public class OrderController : BaseApiController
{
    [HttpPost("CreateOrder")]
    public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(request, cancellationToken));
    }

    [HttpGet("GetOrdersForUser")]
    public async Task<IActionResult> GetOrdersForUser()
    {
        return Ok();
    }
}