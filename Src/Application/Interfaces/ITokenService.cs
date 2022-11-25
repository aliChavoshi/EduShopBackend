using Domain.Entities.Identity;

namespace Application.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}