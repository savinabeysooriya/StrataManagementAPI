using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StrataManagementAPI.Models;
using StrataManagementAPI.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StrataManagementAPI.Services;

public class AuthService(IPasswordHasher passwordHasher, IUserRepository userRepository, IOptions<JwtConfig> jwtConfig) : IAuthService
{
    public async Task<AuthResult> Login(string username, string password)
    {
        var user = await userRepository.GetByUserName(username);

        if (user == null)
        {
            return new AuthResult { Success = false, Errors = ["User not found"] };
        }

        if (!passwordHasher.VerifyPassword(user.PasswordHash, password))
        {
            return new AuthResult { Success = false, Errors = ["Invalid credentials"] };
        }

        var token = GenerateJwtToken(user);
        return new AuthResult { Success = true, Token = token };
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtConfig.Value.Key);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Role, user.Role)
        };

        if (user.BuildingId != null)
        {
            claims.Add(new Claim("buildingId", user.BuildingId));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(jwtConfig.Value.ExpiryInMinutes),
            Issuer = jwtConfig.Value.Issuer,
            Audience = jwtConfig.Value.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
