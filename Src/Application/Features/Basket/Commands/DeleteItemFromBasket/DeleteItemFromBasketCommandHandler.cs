using Application.Contracts;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.BasketEntity;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Basket.Commands.DeleteItemFromBasket;

public class DeleteItemFromBasketCommandHandler : IRequestHandler<DeleteItemFromBasketCommand, CustomerBasket>
{
    private readonly IBasketRepository _basketRepository;

    public DeleteItemFromBasketCommandHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<CustomerBasket> Handle(DeleteItemFromBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await _basketRepository.GetBasketAsync(request.BasketId);
        if (basket == null) throw new NotFoundEntityException("سبد خرید شما یافت نشد");
        basket.Items = basket.Items.Where(x => x.Id != request.ItemId).ToList();
        if (basket.Items.Count == 0) await _basketRepository.DeleteBasketAsync(request.BasketId);
        else await _basketRepository.UpdateBasketAsync(basket);
        return basket;
    }
}