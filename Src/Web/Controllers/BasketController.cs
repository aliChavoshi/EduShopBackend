using Application.Features.Basket.Commands.DeleteBasket;
using Application.Features.Basket.Commands.UpdateBasket;
using Application.Features.Basket.Queries.GetBasketById;
using Domain.Entities.BasketEntity;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers;

public class BasketController : BaseApiController
{
    [HttpGet("{basketId}")]
    public async Task<ActionResult<CustomerBasket>> GetBasketById([FromRoute] string basketId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetBasketByIdQuery(basketId), cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerBasket>> UpdateBasket([FromBody] CustomerBasket basket,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new UpdateBasketCommand(basket), cancellationToken));
    }

    [HttpDelete("{basketId}")]
    public async Task<ActionResult<bool>> DeleteBasket([FromRoute] string basketId, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new DeleteBasketCommand(basketId), cancellationToken));
    }
}