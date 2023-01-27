using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers;

public class OrderController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder()
    {
        return Ok();
    }
}