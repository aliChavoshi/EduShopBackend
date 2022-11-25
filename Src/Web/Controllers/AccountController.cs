using Application.Dtos.Account;
using Application.Features.Account.Commands.CreateAddress;
using Application.Features.Account.Commands.LoginUser;
using Application.Features.Account.Commands.RegisterUser;
using Application.Features.Account.Queries.GetAddresses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers;

public class AccountController : BaseApiController
{
    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginCommand request, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(request, cancellationToken));
    }

    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register([FromBody] RegisterCommand request,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(request, cancellationToken));
    }

    [Authorize]
    [HttpPost("CreateAddress")]
    public async Task<ActionResult<AddressDto>> CreateAddress([FromBody] CreateAddressCommand request,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(request, cancellationToken));
    }

    [Authorize]
    [HttpGet("GetAddresses")]
    public async Task<ActionResult<IEnumerable<AddressDto>>> GetAddresses(CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetAddressesQuery(), cancellationToken));
    }
}