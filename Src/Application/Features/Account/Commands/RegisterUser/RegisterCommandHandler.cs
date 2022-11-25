using Application.Common.Mapping;
using Application.Dtos.Account;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Account.Commands.RegisterUser;

public class RegisterCommand : IRequest<UserDto>, IMapFrom<User>
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string DisplayName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegisterCommand, User>();
    }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, UserDto>
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public RegisterCommandHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var checkUser = await _userManager.Users.AnyAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);
        if (checkUser) throw new BadRequestEntityException("شماره همراه وارد شده تکراری میباشد");

        var user = _mapper.Map<User>(request);
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded) throw new BadRequestEntityException(result.Errors.FirstOrDefault()!.Description);

        var mapUser = _mapper.Map<UserDto>(user);
        mapUser.Token = "";
        return mapUser;
    }
}