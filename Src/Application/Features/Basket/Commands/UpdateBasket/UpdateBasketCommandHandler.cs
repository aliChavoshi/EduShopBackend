using Application.Interfaces;
using Domain.Entities.BasketEntity;
using MediatR;

namespace Application.Features.Basket.Commands.UpdateBasket;

public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, CustomerBasket>
{
    private readonly IBasketRepository _basketRepository;

    public UpdateBasketCommandHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<CustomerBasket> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        return await _basketRepository.UpdateBasketAsync(request.CustomerBasket);
    }
}