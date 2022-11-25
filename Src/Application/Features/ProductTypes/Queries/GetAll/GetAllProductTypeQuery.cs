using Domain.Entities.ProductEntity;
using MediatR;

namespace Application.Features.ProductTypes.Queries.GetAll;

public class GetAllProductTypeQuery : IRequest<IEnumerable<ProductType>>
{

}