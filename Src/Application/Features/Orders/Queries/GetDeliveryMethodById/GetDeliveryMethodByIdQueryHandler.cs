using Application.Contracts;
using Domain.Entities.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Queries.GetDeliveryMethodById;

public class GetDeliveryMethodByIdQuery : IRequest<DeliveryMethod>
{
    public int Id { get; set; }

    public GetDeliveryMethodByIdQuery(int id)
    {
        Id = id;
    }
}

public class GetDeliveryMethodByIdQueryHandler : IRequestHandler<GetDeliveryMethodByIdQuery, DeliveryMethod>
{
    private readonly IUnitOWork _uow;

    public GetDeliveryMethodByIdQueryHandler(IUnitOWork uow)
    {
        _uow = uow;
    }

    public async Task<DeliveryMethod> Handle(GetDeliveryMethodByIdQuery request, CancellationToken cancellationToken)
    {
        return await _uow.Repository<DeliveryMethod>().Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}