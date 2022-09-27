using Application.Contracts;
using Application.Dtos.Products;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ProductEntity;
using MediatR;

namespace Application.Features.Products.Queries.GetAll;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginationResponse<ProductDto>>
{
    private readonly IUnitOWork _uow;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IUnitOWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<PaginationResponse<ProductDto>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new GetProductSpec(request);
        var result = await _uow.Repository<Product>().ListAsyncSpec(spec, cancellationToken);
        var count = await _uow.Repository<Product>().CountAsyncSpec(new ProductsCountSpec(request), cancellationToken);
        var model = _mapper.Map<IEnumerable<ProductDto>>(result);
        return new PaginationResponse<ProductDto>(request.PageIndex, request.PageSize, count, model);
    }
}