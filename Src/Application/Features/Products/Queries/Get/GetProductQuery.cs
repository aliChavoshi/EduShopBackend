using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Products;
using Domain.Entities;
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