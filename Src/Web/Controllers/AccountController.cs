using Application.Features.Account.Commands.RegisterUser;
using Application.Features.Account.Queries.LoginUser;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers;

public class AccountController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Login([FromBody] LoginQuery request, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(request, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterCommand request,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(request,cancellationToken));
    }
}