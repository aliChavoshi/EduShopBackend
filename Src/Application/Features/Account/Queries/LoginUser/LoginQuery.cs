using Application.Dtos.Account;
using MediatR;

namespace Application.Features.Account.Queries.LoginUser;

public class LoginQuery : IRequest<UserDto>
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}