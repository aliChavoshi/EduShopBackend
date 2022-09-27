using MediatR;

namespace Application.Features.Basket.Commands.DeleteBasket;

public class DeleteBasketCommand : IRequest<bool>
{
    public DeleteBasketCommand(string id)
    {
        Id = id;
    }
    public string Id { get; set; }
}