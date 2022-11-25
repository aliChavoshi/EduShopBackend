using Application.Dtos.Products;
using MediatR;

namespace Application.Features.Products.Queries.Get;

public class GetProductQuery : IRequest<ProductDto>
{
    public int Id { get; set; }

    public GetProductQuery(int id)
    {
        Id = id;
    }
}