using Application.Dtos.OrderDto;
using Domain.Entities.Order;
using MediatR;

namespace Application.Features.Orders.Commands.Create;

public class CreateOrderCommand : IRequest<OrderDto>
{
    public string BasketId { get; set; }
    public int DeliveryMethodId { get; set; }
    public string BuyerPhoneNumber { get; set; }
    public ShipToAddress ShipToAddress { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand,OrderDto>
{
    public Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        //1. get basket
        //2. delivery method
        //3. connect get-way => success,link,auth
        //4. reducer => event handler
        //5. create order
        //6. delete basket
        //7. create portal
        //8. create response
        //9. link=> 3.link
        //10. 8.return
        throw new NotImplementedException();
    }
}