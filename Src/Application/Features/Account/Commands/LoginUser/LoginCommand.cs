using Application.Dtos.Account;
using MediatR;

namespace Application.Features.Account.Commands.LoginUser;

public class LoginCommand : IRequest<UserDto>
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}