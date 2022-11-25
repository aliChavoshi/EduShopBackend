using Application.Interfaces;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration configuration, UserManager<User> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTConfiguration:Key"] ?? string.Empty));
    }

    public async Task<string> CreateToken(User user)
    {
        if (user.PhoneNumber == null) return null;
        //create claims
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.GivenName, user.DisplayName ?? ""),
            new(JwtRegisteredClaimNames.NameId, user.Id ?? ""),
            new("PhoneNumber", user.PhoneNumber ?? "")
        };
        //add roles to claims
        var roles = await _userManager.GetRolesAsync(user);
        if (roles.Any())
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        //create token
        var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Issuer = _configuration["JWTConfiguration:Issuer"],
            Audience = _configuration["JWTConfiguration:Audience"],
            IssuedAt = DateTime.Now,
            Expires = DateTime.UtcNow.AddDays(10),
            SigningCredentials = cred,
            Subject = new ClaimsIdentity(claims)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return await Task.Run(() => tokenHandler.WriteToken(token)).ConfigureAwait(false);
    }
}