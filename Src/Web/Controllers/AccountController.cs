using Application.Features.Account.Commands.LoginUser;
using Application.Features.Account.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers;

public class AccountController : BaseApiController
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand request, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(request, cancellationToken));
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand request, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(request, cancellationToken));
    }
}