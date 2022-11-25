using Application.Common.Mapping;
using Application.Contracts;
using Application.Dtos.Account;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Application.Features.Account.Commands.CreateAddress;

public class CreateAddressCommand : IRequest<AddressDto>, IMapFrom<Address>
{
    public bool IsMain { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string FirstName { get; set; }
    public string FullAddress { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
    public string PostalCode { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateAddressCommand, Address>();
    }
}

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, AddressDto>
{
    private readonly IUnitOWork _unitOWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly UserManager<User> _userManager;

    public CreateAddressCommandHandler(IUnitOWork unitOWork, IMapper mapper, ICurrentUserService currentUserService,
        UserManager<User> userManager)
    {
        _unitOWork = unitOWork;
        _mapper = mapper;
        _currentUserService = currentUserService;
        _userManager = userManager;
    }

    public async Task<AddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var user = await _userManager.Users.Include(x => x.Addresses)
            .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
        if (user == null) throw new NotFoundEntityException();
        if (request.IsMain && user.Addresses.Any())
        {
            //remove is main addresses
            user.Addresses.ForEach(x => x.IsMain = false);
        }

        if (!user.Addresses.Any()) request.IsMain = true;
        var entity = _mapper.Map<Address>(request);
        entity.UserId = userId;
        user.Addresses.Add(entity);
        var userResult = await _userManager.UpdateAsync(user);
        if (!userResult.Succeeded)
            throw new BadRequestEntityException();
        return _mapper.Map<AddressDto>(entity);
    }
}