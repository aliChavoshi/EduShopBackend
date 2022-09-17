using Application.Features.ProductBrands.Queries.GetAll;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers;

public class ProductBrandController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductBrand>>> Get(CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetAllProductBrandQuery(), cancellationToken));
    }
}