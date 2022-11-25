using Application.Interfaces;
using MediatR;

namespace Application.Features.Basket.Commands.DeleteBasket;

public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, bool>
{
    private readonly IBasketRepository _basketRepository;

    public DeleteBasketCommandHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        return await _basketRepository.DeleteBasketAsync(request.Id);
    }
}