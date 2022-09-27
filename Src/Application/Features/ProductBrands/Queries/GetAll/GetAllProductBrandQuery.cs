using Domain.Entities;
using Domain.Entities.ProductEntity;
using MediatR;

namespace Application.Features.ProductBrands.Queries.GetAll;

public class GetAllProductBrandQuery : IRequest<IEnumerable<ProductBrand>>
{
}