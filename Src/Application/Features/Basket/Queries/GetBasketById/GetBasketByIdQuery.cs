using Domain.Entities.BasketEntity;
using MediatR;

namespace Application.Features.Basket.Queries.GetBasketById;

public class GetBasketByIdQuery : IRequest<CustomerBasket>
{
    public GetBasketByIdQuery(string id)
    {
        Id = id;
    }
    public string Id { get; set; }
}