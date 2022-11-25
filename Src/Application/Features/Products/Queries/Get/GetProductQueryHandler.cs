using Application.Contracts;
using Application.Dtos.Products;
using Application.Features.Products.Queries.GetAll;
using AutoMapper;
using Domain.Entities.ProductEntity;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Products.Queries.Get;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IUnitOWork _uow;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IUnitOWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetProductSpec(request.Id);
        var result = await _uow.Repository<Product>().GetEntityWithSpec(spec, cancellationToken);
        if (result == null) throw new NotFoundEntityException();
        return _mapper.Map<ProductDto>(result);
    }
}