using Domain.Entities.Identity;

namespace Application.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(User user);
}