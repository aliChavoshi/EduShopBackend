using Domain.Entities.BasketEntity;
using MediatR;

namespace Application.Features.Basket.Commands.DeleteItemFromBasket;

public class DeleteItemFromBasketCommand : IRequest<CustomerBasket>
{
    public string BasketId { get; set; }
    public int ItemId { get; set; }

    public DeleteItemFromBasketCommand(string basketId, int itemId)
    {
        BasketId = basketId;
        ItemId = itemId;
    }
}