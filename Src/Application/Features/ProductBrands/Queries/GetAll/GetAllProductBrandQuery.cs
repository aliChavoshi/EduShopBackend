using Domain.Entities;
using MediatR;

namespace Application.Features.ProductBrands.Queries.GetAll;

public class GetAllProductBrandQuery : IRequest<IEnumerable<ProductBrand>>
{
}