using Application.Dtos.OrderDto;
using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Queries.GetOrderByIdForUser;
using Application.Features.Orders.Queries.GetOrdersForUser;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<ActionResult<List<OrderDto>>> GetOrdersForUser(CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetOrdersForUserQuery(), cancellationToken));
    }

    [HttpGet("GetOrderByIdForUser/{id:int}")]
    public async Task<ActionResult<OrderDto>> GetOrderByIdForUser([FromRoute] int id,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetOrderByIdForUserQuery(id), cancellationToken));
    }

    [HttpGet("GetDeliveryMethods")]
    public async Task<IActionResult> GetDeliveryMethods(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("GetDeliveryMethodById/{id:int}")]
    public async Task<IActionResult> GetDeliveryMethodById([FromRoute] int id, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("Verify")]
    [AllowAnonymous]
    //TODO
    public async Task<IActionResult> Verify(string authority, string status, CancellationToken cancellationToken)
    {
        return Redirect("");
    }
}