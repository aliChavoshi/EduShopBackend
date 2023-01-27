using Application.Contracts;
using Application.Dtos.OrderDto;
using AutoMapper;
using Domain.Entities.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Queries.GetOrderByIdForUser;

public class GetOrderByIdForUserQuery : IRequest<OrderDto>
{
    public int Id { get; set; }

    public GetOrderByIdForUserQuery(int id)
    {
        Id = id;
    }
}

public class GetOrderByIdForUserQueryHandler : IRequestHandler<GetOrderByIdForUserQuery, OrderDto>
{
    private readonly IUnitOWork _unitOWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public GetOrderByIdForUserQueryHandler(IUnitOWork unitOWork, IMapper mapper, ICurrentUserService currentUserService)
    {
        _unitOWork = unitOWork;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<OrderDto> Handle(GetOrderByIdForUserQuery request, CancellationToken cancellationToken)
    {
        var order = await _unitOWork.Repository<Order>().Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        return _mapper.Map<OrderDto>(order);
    }
}