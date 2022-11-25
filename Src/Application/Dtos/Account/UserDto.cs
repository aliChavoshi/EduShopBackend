using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Identity;

namespace Application.Dtos.Account;

public class UserDto : IMapFrom<User>
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public string NationalCode { get; set; }
    public string DisplayName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDto>().ReverseMap();
    }
}